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

        public static String xmlFile = System.Windows.Forms.Application.StartupPath + "\\config.xml";
        const String mTableName = "param";

        DataTable mTableSerial=new DataTable("Serial");
        DataTable mTableServer=new DataTable("Server");
        DataTable mTableClient = new DataTable("Client");
        DataTable mTableRelay = new DataTable("Relay");
        DataSet mDataSet = new DataSet();

        private List<DataGridView> mGrids=new List<DataGridView>();

        public FrmParam()
        {
            InitializeComponent();
        }
      

        public static DataSet ReadXml()
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
            
            if (grid.EditingControl != null)
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
            for(int i = 0; i < cols; i++)
            {
                dgCell = dgRow.Cells[i];
                if (dgCell.ValueType == typeof(Boolean))
                {
                    dtRow[i] = dgCell.Selected;
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
                ret.Columns.Add(grid.Columns[i].Name);
            }
            return ret;
        }

        /// <summary>
        /// 表格控件内容转换为数据表内容
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
        

        private void WndOK_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            foreach (DataGridView item in mGrids)
            {
                if (item.EditingControl != null)
                {
                    item.EndEdit();  //更新编辑
                }
                DataTable dt = GridToTable(item);
                ds.Tables.Add(dt);
            }
            ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);
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
            mGrids.Add(GridSerial);
            mGrids.Add(GridServer);
            mGrids.Add(GridClient);
            mGrids.Add(GridRelay);


            TabParam.Dock = DockStyle.Fill;
            GridServer.Dock = DockStyle.Fill;
            GridSerial.Dock= DockStyle.Fill;
            GridClient.Dock = DockStyle.Fill;
            GridRelay.Dock = DockStyle.Fill;

            GridServer.AutoGenerateColumns = false;
            GridClient.AutoGenerateColumns = false;
            GridSerial.AutoGenerateColumns = false;
            GridRelay.AutoGenerateColumns = false;

            mDataSet = ReadXml();
            DataTable dt1, dt2, dt3,dt4;
            if (mDataSet != null)
            {
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
    }
}
