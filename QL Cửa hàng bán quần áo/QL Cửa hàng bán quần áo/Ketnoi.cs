using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cửa_hàng_bán_quần_áo
{
    public class Ketnoi
    {

        public static SqlConnection Conn;
        public static string connString;
        public static void Connect()
        {
            connString = "Data Source=NGHIA\\SQLEXPRESS03;Initial Catalog=QlyCuaHangQuanAo;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();
            Conn.ConnectionString = connString;
            Conn.Open();

        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;

            }
        }
        public static DataTable Getdatatotable(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter();
            mydata.SelectCommand = new SqlCommand();
            mydata.SelectCommand.Connection = Ketnoi.Conn;
            mydata.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            mydata.Fill(table);
            return table;
        }
        // viết hàm checkkey để kiểm tra trùng mã
        public static bool checkey(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Ketnoi.Conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            if (table.Rows.Count > 0) { return true; }
            else { return false; }
        }
        // viết thủ tục runsql để thực thi câu lệnh sql
        public static void runsql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = Ketnoi.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

    }


}
