using com;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetToSerial
{
    public partial class FrmParam : Form
    {
        public const String s_GridSerial = "GridSerial";
        public const String s_GridServer = "GridServer";
        public const String s_GridClient = "GridClient";
        public const String s_GridRelay =  "GridRelay";

        public static String xmlFile = System.Windows.Forms.Application.StartupPath + "\\config.xml";
        const String mTableName = "param";

        DataSet mDataSet = new DataSet();

        public FrmParam()
        {
            InitializeComponent();
        }
      

        public static DataSet ReadDataSet()
        {
            DataSet ret = new DataSet();
            if (System.IO.File.Exists(xmlFile))
            {
                try
                {
                    ret.ReadXml(xmlFile);
                }
                catch(Exception ex)
                {
                    Log.Err("获取参数失败:"+ ex.Message);
                }
            }
            return ret;
        }


        

        /// <summary>
        /// 相同/递增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="inc"></param>
        private void OnAdd(object sender, EventArgs e, int inc)
        {
            DataGridView grid = GetSelect();
            
            if (grid.IsCurrentCellInEditMode)
            {
                grid.EndEdit();
            }


            DataGridViewCell cell = grid.CurrentCell;
            if (cell == null)
            {
                return;
            }

            try
            {
                String textValue = Convert.ToString(cell.Value); ;
                long longValue = 0;
                if (inc != 0)
                {
                    longValue = Convert.ToInt64(cell.Value);
                }

                int rowIndex = cell.RowIndex;
                int colIndex = cell.ColumnIndex;
                int rowCount = grid.RowCount;
                for (int i = rowIndex + 1; i < rowCount; i++)
                {
                    if (inc > 0)
                    {
                        longValue += inc;
                        grid.Rows[i].Cells[colIndex].Value = longValue;
                    }
                    else
                    {
                        grid.Rows[i].Cells[colIndex].Value = textValue;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Err(ex.Message);
            }
        }

        /// <summary>
        /// 相同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndEqual_Click(object sender, EventArgs e)
        {
            OnAdd(sender, e, 0);
        }

        /// <summary>
        /// 递增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndAdd_Click(object sender, EventArgs e)
        {
            OnAdd(sender, e, 1);
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndDeleteRows_Click(object sender, EventArgs e)
        {

            DataGridView grid = GetSelect();
            DataGridViewSelectedRowCollection rs = grid.SelectedRows;
            if (rs.Count > 0)
            {
                foreach (DataGridViewRow item in rs)
                {
                    grid.Rows.Remove(item);
                }
            }
            else if (grid.CurrentCell!=null)
            {
                grid.Rows.RemoveAt(grid.CurrentCell.RowIndex);
            }

        }

        /// <summary>
        /// 获取选定表格视图
        /// </summary>
        /// <returns></returns>
        public DataGridView GetSelect()
        {
            DataGridView[] grids = {GridSerial,GridServer,GridClient,GridRelay};
            int index=TabParam.SelectedIndex;
            return grids[index];
        }

        /// <summary>
        /// 增加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndAddRow_Click(object sender, EventArgs e)
        {
            DataGridView grid = GetSelect();
            DataTable dt = grid.DataSource as DataTable;
            dt.Rows.Add(dt.NewRow());
        }


        /// <summary>
        /// 表格控件行转换为数据表行
        /// </summary>
        /// <param name="dgRow"></param>
        /// <param name="dtRow"></param>
        void GridRowToDataRow(DataGridViewRow dgRow, DataRow dtRow)
        {
            int cols = dgRow.Cells.Count;
            DataGridViewCell dgCell;
            Object cellValue;
            for (int i = 0; i < cols; i++)
            {
                dgCell = dgRow.Cells[i];
                cellValue = dgCell.Value;
                if (cellValue == null || cellValue.GetType()==typeof(DBNull))
                {
                    dtRow[i] = dgCell.Style.NullValue;// .OwningColumn.CellTemplate.Style.NullValue;
                }
                else
                {
                    dtRow[i] = dgRow.Cells[i].Value;
                }
            }
        }

        /// <summary>
        /// 根据表格视图创建数据表
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        DataTable CreateTable(DataGridView grid)
        {
            DataTable ret = new DataTable(grid.Name);
            int count=grid.ColumnCount;
            for(int i = 0; i < count; i++)
            {
                //DataGridViewColumn column = grid.Columns[i];
                //Type ct = column.CellType;
                //if (ct == typeof(DataGridViewCheckBoxCell))
                //{
                //    ret.Columns.Add(grid.Columns[i].Name, typeof(Boolean));
                //}
                //else
                //{
                //    ret.Columns.Add(grid.Columns[i].Name);
                //}
                if (i == 0)
                {
                    ret.Columns.Add(grid.Columns[i].Name,typeof(Boolean));
                }
                else
                {
                    ret.Columns.Add(grid.Columns[i].Name);
                }

            }
            return ret;
        }

        /// <summary>
        /// 表格控件内容转换为数据表内容,数据表名称=表格名称 ,数据列名称=表格列名称
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        DataTable GridToTable(DataGridView grid)
        {
            DataTable dt = CreateTable(grid);
            int rows = grid.RowCount;
            int cols = grid.ColumnCount;
            DataRow dtRow;
            DataGridViewRow dgRow;
            for (int i = 0; i < rows; i++)
            {
                dtRow=dt.NewRow();
                dgRow= grid.Rows[i];
                GridRowToDataRow(dgRow, dtRow);
                dt.Rows.Add(dtRow);
            }
            return dt;
        }

        DataGridView[] GetDataGridViews()
        {
            DataGridView[] ret = { GridSerial, GridServer, GridClient, GridRelay };
            return ret;
        }


        private void OnSave()
        {
            DataGridView[] grids = GetDataGridViews();
            DataSet ds = new DataSet();
            foreach (DataGridView item in grids)
            {
                if (item.IsCurrentCellInEditMode)
                {
                    item.EndEdit();  //更新编辑
                }
                DataTable dt = GridToTable(item);
                ds.Tables.Add(dt);
            }
            ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
        }

        private void WndOK_Click(object sender, EventArgs e)
        {
            OnSave();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void WndCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      

        private void FrmParam_Load(object sender, EventArgs e)
        {
 
            TabParam.Dock = DockStyle.Fill;
            mDataSet = ReadDataSet();
            DataGridView[] grids = GetDataGridViews();
            foreach (DataGridView item in grids)
            {
                item.Dock = DockStyle.Fill;
                item.AutoGenerateColumns = false;
                DataTable dt = mDataSet.Tables[item.Name];
                if (dt == null)
                {
                    dt = CreateTable(item);
                }
                item.DataSource = dt;
            }

        }

        private void WndGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }


        private void RowStateChanged(DataGridView dg)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                DataGridViewRow r = dg.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", i + 1);
            }
            dg.Refresh();
        }

        private void GridSerial_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            RowStateChanged(sender as DataGridView);
        }
        private void GridClient_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            RowStateChanged(sender as DataGridView);
        }

        private void GridRelay_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            RowStateChanged(sender as DataGridView);
        }
        private void GridServer_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            RowStateChanged(sender as DataGridView);
        }
        /// <summary>
        /// 重新设置右键菜单内容 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSerial_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            menu.Items.Clear();
            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach(String item in ports)
            {
                menu.Items.Add(item);
            }
            e.Cancel = false;
        }

        private void MenuSerial_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GridSerial.CurrentCell.Value = e.ClickedItem.Text.Substring(3);
        }

        private void MenuBaud_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GridSerial.CurrentCell.Value = e.ClickedItem.Text;
        }

        private void MenuParity_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GridSerial.CurrentCell.Value = e.ClickedItem.Text.Substring(0, 1);
        }

        private void GridSerial_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void GridClient_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void GridRelay_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void wndSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }
    }
}
