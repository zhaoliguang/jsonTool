using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace teachJson
{

        public class DBHelper
        {
            public SQLiteConnection GetCon()
            {
                string strFilePath = @"Data Source=clientdb.db";
                string strCon = strFilePath + ";Pooling=true;FailIfMissing=false";
                SQLiteConnection sqliteCon = new SQLiteConnection(strCon);
                return sqliteCon;
            }
        }

        public class SqlHelper : DBHelper
        {
            private DataTable dt;
            private SQLiteConnection conn;
            private SQLiteCommand cmd;
            private SQLiteDataAdapter sda;
            /// <summary>
            /// 数据库操作类
            /// </summary>
            /// <param name="sql"></param>
            /// <returns></returns>
            public int RunSQL(string sql)
            {
                int count = 0;
                try
                {
                    conn = GetCon();
                    conn.Open();
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    count = count + 1;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return count;
            }
            /// <summary>
            /// 获得datatable
            /// </summary>
            /// <param name="sql"></param>
            /// <returns></returns>
            public DataTable GetDataTable(string sql)
            {
                DataSet ds = null;
                try
                {
                    conn = GetCon();
                    sda = new SQLiteDataAdapter(sql, conn);//OracleDataAdapter：网络适配器
                    ds = new DataSet();
                    sda.Fill(ds);//将结果填充到ds中
                    dt = ds.Tables[0];
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }
            /// <summary>
            /// 返回记录总条数
            /// </summary>
            /// <param name="strTableName"></param>
            /// <returns></returns>
            public int GetCount(string strTableName)
            {
                string strSql = "select count(*) from " + strTableName;
                int count = 0;
                DataTable dtCount = GetDataTable(strSql);
                count = int.Parse(dtCount.Rows[0][0].ToString());
                return count;
            }
        }


    }

