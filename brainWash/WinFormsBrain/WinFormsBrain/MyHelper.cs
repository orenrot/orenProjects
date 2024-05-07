using System;
using System.Data;
using System.Data.SqlClient;

namespace WinFormBrainWash
{
    public class MyHelper
    {
        private string path;
        private string connectionString;
        public MyHelper() { }
        public SqlConnection ConnectToDb(string fileName)//קישור למסד נתונים
        {
            //    path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד הנתונים בפרוייקט
            //   path += fileName;
            //   connectionString = @"Data Source=(LocalDB)MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            //  path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד הנתונים בפרוייקט
            //   path += fileName;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Downloads\entity\DataWords.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;//מחזיר קשר לטבלה במסד נתונים
        }
        //-------------------------------------------------------------------------------
        // return DataSet object
        //disconected
        public DataSet GetDataSet(string cmdString, string fileName)//לקבלת דאט סט
        {
            // SqlTransaction trans = null;///טרנזקציה
            SqlConnection connection = ConnectToDb(fileName);//קשר לטבלה
            SqlDataAdapter adapter = new SqlDataAdapter(cmdString, connection);//מכין אותו לביצוע פעולה
            DataSet ds = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                //  adapter.UpdateCommand.Transaction = trans;
                connection.Open();//פתיחת הקשר
                adapter.Fill(ds, fileName);//ימלא את הטבלה בנתונים שיש
            }
            catch (Exception exp) { }
            finally { connection.Close(); }
            return ds;
        }

        //-------------------------------------------------------------------------------
        // return DataSet object
        //disconected
        public DataSet GetDataSetForOrders(string cmdString, string flie)//לקבלת דאט סאט של הזמנות
        {
            SqlConnection connection = ConnectToDb(flie);//קשר לטבלה
            SqlDataAdapter adapter = new SqlDataAdapter(cmdString, connection);//מכין אותו לביצוע פעולה
            DataSet ds = new DataSet();//מכין דאטה סט לאגירת המידע שאנחנו נבקש ממנו לשמור
            try
            {
                connection.Open();//פתיחת הקשר
                adapter.Fill(ds, "OfferForPrice");//ימלא את הטבלה בנתונים שיש
            }
            catch (Exception exp) { }
            finally { connection.Close(); }
            return ds;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string getStringFromDataSet(DataSet ds)//מחזיר מחרוזת עם שתי העמודות הראשונות למה שמתאים
        {
            string result = null;
            //option 1:
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                result += ds.Tables[0].Rows[i][0] + "\t" + ds.Tables[0].Rows[i][1] + "\n";
            //option 2: שימוש בשם הטבלה ושמות העמודות שלה
            return result;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ExecuteDataTable(string cmdString, string flie)//שיחזיר דטא טבלה של מה שמבקשים ממנו
        {
            SqlConnection connection = ConnectToDb(flie);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(cmdString, connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                tableAdapter.Fill(dt);
            }
            catch (Exception exp) { }
            finally { connection.Close(); }
            return dt;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetStringForBuyerId(string cmdString, string flie)//לקבל את שם הקונה
        {
            string result = null;
            SqlConnection connection = ConnectToDb(flie);//מוצא את הקשר
            SqlCommand command = new SqlCommand(cmdString, connection);//מכין אותו לביצוע פעולה

            try
            {
                connection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = command.ExecuteReader();//מתחיל בביצוע הפעולה
                                                                   // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
                while (dataReader.Read())
                {
                    result += dataReader["BuyerId"].ToString() + " ";

                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                connection.Close();
            }
            return result;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  FullConnected : SELECT QUERY
        public string DoSelectQuery(string cmdString, string flie)
        {
            string result = null;
            SqlConnection connection = ConnectToDb(flie);//מוצא את הקשר
            SqlCommand command = new SqlCommand(cmdString, connection);//מכין אותו לביצוע פעולה

            try
            {
                connection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = command.ExecuteReader();//מתחיל בביצוע הפעולה
                                                                   // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
                while (dataReader.Read())
                {
                    result += dataReader["UserName"].ToString() + " ";
                    result += dataReader["password"].ToString() + " ";
                    result += dataReader["lastName"].ToString() + " ";
                    result += dataReader["address"].ToString() + " ";
                    result += dataReader["email"].ToString() + " ";
                    result += dataReader["firstName"].ToString() + " ";
                    result += dataReader["DateBorn"].ToString() + " ";
                    result += dataReader["phonenumber"].ToString() + " ";
                    result += dataReader["OptionInWeb"].ToString() + "</br>";
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                connection.Close();
            }
            return result;
        }
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string getStringFromDataTable(DataTable dt)//לקבל שורה מטבלה של דאט טיבל
        {
            string result = "<table border='1'>";
            foreach (DataRow row in dt.Rows)
            {
                result += "<tr>";
                foreach (object myItemArray in row.ItemArray)
                    result += "<td>" + myItemArray.ToString() + "</td>";
                result += "</tr>";
            }
            result += "</table>";
            return result;
        }
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoSelectWhisList(string cmdString, string flie)//כדילקבל את הנתונים של הווישט ליסט
        {
            string result = null;
            SqlConnection connection = ConnectToDb(flie);//מוצא את הקשר
            SqlCommand command = new SqlCommand(cmdString, connection);//מכין אותו לביצוע פעולה

            try
            {
                connection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = command.ExecuteReader();//מתחיל בביצוע הפעולה
                                                                   // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
                while (dataReader.Read())
                {
                    result += dataReader["WhisListId"].ToString() + " ";
                    result += dataReader["ProductId"].ToString() + "</br>";
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                connection.Close();
            }
            return result;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Boolean DoQuery(string cmdString, string flie)//בשביל עדכון מחיקה
        { //הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
          //ומבצעת את הפקודה על המסד הפיזי
            Boolean result = true;
            SqlConnection connection = ConnectToDb(flie);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmdString, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception exp) { result = false; }
            finally
            {
                connection.Close();
            }
            return result;
        }
        /// ///////////////////////////////.......................................////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoStoreProcedureWithParameter(string myStoreProcedure, string parameter, string flie)//עדכון עם פרמטר או הכנסת רשומה על ידי שימוש באספי
        {
            string result = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);//מכין אותו לביצוע פעולה
            myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();
                // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
                while (dataReader.Read())
                {
                    result += dataReader["UserName"].ToString() + " ";
                    result += dataReader["password"].ToString() + " ";
                    result += dataReader["lastName"].ToString() + " ";
                    result += dataReader["address"].ToString() + " ";
                    result += dataReader["email"].ToString() + " ";
                    result += dataReader["firstName"].ToString() + " ";
                    result += dataReader["DateBorn"].ToString() + " ";
                    result += dataReader["phonenumber"].ToString() + " ";
                    result += dataReader["OptionInWeb"].ToString() + "</br>";
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoStoreProcedureWithParameterGetPrice(string myStoreProcedure, string parameter, string flie)//לקבלת מחיר
        {
            string result = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;//שידע שזה סוג של שאילתה מאוחסנת
            myCommand.Parameters.AddWithValue("@ProductId", parameter);//שידע שזה עם פרמטר וזה הפרמטר
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    result += dataReader["Price"].ToString() + " ";
                }
                dataReader.Close();//שהדאטה רידר יסגר

            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoStoreProcedureWithParameterGetAmount(string myStoreProcedure, string parameter, string paramater2, string flie)//לקבלת כמות על ידי בקשה על ידי שני פרמטרים עם שימוש באספי
        {
            string result = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;//שידע שזה סוג של שאילתה מאוחסנת
            myCommand.Parameters.AddWithValue("@ProductId", parameter);//שידע שזה עם פרמטר וזה הפרמטר של המספר הייחודי של המוצר
            myCommand.Parameters.AddWithValue("@Amount", paramater2);//שידע שזה עם פרמטר וזה הפרמטר של הכמות
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    result += dataReader["ProductAmount"].ToString() + " ";
                }
                dataReader.Close();//שהדאטה רידר יסגר

            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int DoStoreProcedureWithParameterGetCurrectAmount(string myStoreProcedure, string parameter, string flie)//לקבלת כמות נוכחית של מוצר
        {
            int result = 0;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;//שידע שזה סוג של שאילתה מאוחסנת
            myCommand.Parameters.AddWithValue("@ProductId", parameter);//שידע שזה עם פרמטר וזה הפרמטר של המספר הייחודי של המוצר
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    result = int.Parse(dataReader["ProductAmount"].ToString());
                }
                dataReader.Close();//שהדאטה רידר יסגר

            }
            catch (Exception exp) { }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoSelectQueryForOffer(string cmdString, string flie)//לעדכון
        {
            string result = null;
            SqlConnection connection = ConnectToDb(flie);//מוצא את הקשר
            SqlCommand command = new SqlCommand(cmdString, connection);//מכין אותו לביצוע פעולה

            //try
            //{
            connection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
            SqlDataReader dataReader = command.ExecuteReader();//מתחיל בביצוע הפעולה
            // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
            while (dataReader.Read())
            {
                result += dataReader["DateId"].ToString() + " ";
                result += dataReader["BuyerId"].ToString() + " ";
                result += dataReader["ProductId"].ToString() + " ";
                result += dataReader["amount"].ToString() + " ";
                result += dataReader["StartPrice"].ToString() + " ";
                result += dataReader["SalePerrcent"].ToString() + " ";
                result += dataReader["StatusOffer"].ToString() + " ";
                result += dataReader["StatusDescription"].ToString() + "</br>";
            }
            dataReader.Close();//שהדאטה רידר יסגר
                               //   }
                               //    catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
                               //     finally
                               //    {
            connection.Close();
            //      }
            return result;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ExecuteNonQuery(string cmdString, string flie)//יבצע את השאילתות למשל שאילתת מחיקה
        {
            SqlConnection connection = ConnectToDb(flie);//קשר למסד נתונים
            SqlCommand command = new SqlCommand(cmdString, connection);////מכין אותו לביצוע פעולה
            try
            {
                connection.Open();//פתיחת הקשר
                command.ExecuteNonQuery();//ביצוע הפעולה
            }
            catch (Exception exp) { }
            finally { connection.Close(); }
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string DoStoreProcedureWitTwohParameter(string myStoreProcedure, string parameter, string paramter2, string flie)/////////עדיין לא נבדק צריך לעבוד על זה
        {
            string result = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);//מכין אותו לביצוע פעולה
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@username", parameter);//שידע שזה עם פרמטר וזה הפרמטר של המספר הייחודי של המוצר
            myCommand.Parameters.AddWithValue("@firstName", paramter2);//שידע שזה עם פרמטר וזה הפרמטר של הכמות
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();
                // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
                while (dataReader.Read())
                {
                    result += dataReader["UserName"].ToString() + " ";
                    result += dataReader["password"].ToString() + " ";
                    result += dataReader["lastName"].ToString() + " ";
                    result += dataReader["address"].ToString() + " ";
                    result += dataReader["email"].ToString() + " ";
                    result += dataReader["firstName"].ToString() + " ";
                    result += dataReader["DateBorn"].ToString() + " ";
                    result += dataReader["phonenumber"].ToString() + " ";
                    result += dataReader["OptionInWeb"].ToString() + "</br>";
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public double DoStoreProcedureWithParameterGetPriceInt(string myStoreProcedure, string parameter, string flie)//משנה את המחיר
        {
            double result = 0.00;
            string result2 = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(myStoreProcedure, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;//שידע שזה סוג של שאילתה מאוחסנת
            myCommand.Parameters.AddWithValue("@ProductId", parameter);//שידע שזה עם פרמטר וזה הפרמטר
            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    result = double.Parse(dataReader["Price"].ToString()) + double.Parse(dataReader["ShipmentCoast"].ToString());
                }
                dataReader.Close();//שהדאטה רידר יסגר
                result2 = result.ToString();
            }
            catch (Exception exp) { result2 = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string[] DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier(string cmdString, int number, string flie)//סטרינג עם הפעולה שאנחנו רוצים לדעת מהם המוצרים של הספק ומספר של כמה מוצרים יש לו
        {
            string[] result = new string[number];
            int cnt = 0;
            string result2 = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(cmdString, myConnection);

            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    result[cnt] = dataReader["ProductId"].ToString();
                    cnt++;
                    //  result = double.Parse(dataReader["Price"].ToString()) + double.Parse(dataReader["ShipmentCoast"].ToString());
                }
                dataReader.Close();//שהדאטה רידר יסגר
                result2 = result.ToString();
            }
            catch (Exception exp) { result2 = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string[] DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier2(string cmdString, int number, string flie)// פעולה בשביל לדעת איזה מספרים של מוצרים הקונה הזמין
        {
            string[] result = new string[number];//למספרים של הזמנות
            int cnt = 0;
            int cnt2 = 0;
            string result2 = null;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(cmdString, myConnection);

            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    if (cnt > 0)//אם זה לא פעם ראשונה
                        for (int k = 0; k < cnt; k++)
                        {

                            if (result[k] != dataReader["ProductId"].ToString())//בדיקה אם זה לא נמצא במערך
                                cnt2++;//לספור אם זה כל הזמן לא נמצא במערך
                        }
                    if (cnt == cnt2)
                    {
                        result[cnt] = dataReader["ProductId"].ToString();//הכנסת האיבר החדש למערך
                        cnt2 = 0;//לאפס את המספר שמצאנו אם זה מתאים כדי להוסיף למערך או לא
                        cnt++;//להבא בתור

                    }
                    if (cnt == 0)//פעם ראשונה
                    {

                        result[cnt] = dataReader["ProductId"].ToString();//הכנסת האיבר החדש למערך
                        cnt++;//להבא בתור

                    }
                    cnt2 = 0;//לאפס את המספר שמצאנו אם זה מתאים כדי להוסיף למערך או לא
                }
                dataReader.Close();//שהדאטה רידר יסגר
                result2 = result.ToString();
            }
            catch (Exception exp) { result2 = "An Error has occur please come back later we fix it"; }
            finally
            {
                myConnection.Close();
            }
            return result;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int AmountOfProductIds(string cmdString, string flie)//יחזיר את מספר הפעמים שיש לאותו אדם מוצרים שהוא הזמין
        {
            int a = 0;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(cmdString, myConnection);

            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    a++;
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { }
            finally
            {
                myConnection.Close();
            }
            return a;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int AmountOfProductIdsFromWhisList(string cmdString, string flie)//כדי לראות כמה מוצרים יש ברשימת המשאלות של אותו משתמש
        {
            int a = 0;
            SqlConnection myConnection = ConnectToDb(flie);
            SqlCommand myCommand = new SqlCommand(cmdString, myConnection);

            try
            {
                myConnection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
                SqlDataReader dataReader = myCommand.ExecuteReader();//מתחיל בביצוע הפעולה
                while (dataReader.Read())
                {
                    a++;
                }
                dataReader.Close();//שהדאטה רידר יסגר
            }
            catch (Exception exp) { }
            finally
            {
                myConnection.Close();
            }
            return a;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int DoSelectScalarQuery(string fileName, string cmdString)//לבדיקת שאילתות אם קיים משהו למשל בהתחברות אם קיים שם משתמש וסיסמא כזו
        {
            int result = 0;
            SqlConnection connection = ConnectToDb(fileName);
            SqlCommand command = new SqlCommand(cmdString, connection);
            try
            {
                connection.Open();
                result = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception exp) { }
            finally { connection.Close(); }
            return result;
        }
    }
}