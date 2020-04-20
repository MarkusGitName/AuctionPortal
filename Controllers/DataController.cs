using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AuctionPortal.Models;

namespace AuctionPortal.Controllers
{
    public class DataController
    {

        public static string db = "DefaultConnection";

        public static DataTable getAuctions()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable AuctionsTable = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from Auctions order by StartTime desc", con);
                adpAuctions.Fill(AuctionsTable);
            }
            catch (DataException e)
            {
                throw e;
            }

            return AuctionsTable;
        }
        public static DataTable getAuctionsNotExpired()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable AuctionsTable = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from Auctions where endTime >='" + DateTime.Now + "' order by StartTime desc", con);
                adpAuctions.Fill(AuctionsTable);
            }
            catch (DataException e)
            {
                throw e;
            }

            return AuctionsTable;
        }

        public static DataTable getProperty()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;


            DataTable PropertyTable = new DataTable();

            try
            {
                SqlDataAdapter adpProperties = new SqlDataAdapter("SELECT * from Property", con);
                adpProperties.Fill(PropertyTable);

            }
            catch (DataException e)
            {
                throw e;
            }

            return PropertyTable;
        }
        public static newAddProppertyViewModel getPropertyAt(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            newAddProppertyViewModel model = new newAddProppertyViewModel();

            DataTable PropertyTable = new DataTable();

            try
            {
                SqlDataAdapter adpProperties = new SqlDataAdapter("SELECT * from Property Where PropertyID = '" + id + "'", con);
                adpProperties.Fill(PropertyTable);

            }
            catch (DataException e)
            {
                throw e;
            }
            foreach (DataRow row in PropertyTable.Rows)
            {
                model.Address = row.ItemArray[1].ToString();
                model.OpeningBid = Convert.ToDouble(row.ItemArray[2]);
                model.Description = row.ItemArray[3].ToString();
                model.Documents = row.ItemArray[4].ToString();
                model.Location = row.ItemArray[5].ToString();

            }
            return model;

        }
        public static void InsertProperty(string address, double OpeningBid, string description, string Documents, string Location)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Property (Address, OpeningBid, Description, Documents, Location) Values('" + address + "','" + OpeningBid + "','" + description + "','" + Documents + "','" + Location + "')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
        }
        public static void InsertProperty2(newAddProppertyViewModel model)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Property (Address, OpeningBid, Reserve,  Description, Documents, Location) Values('" + model.Address + "','" + model.OpeningBid + "','" + model.Reserve + "','" + model.Description + "','" + model.Documents + "','" + model.Location + "')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
        }

        public static DataTable getUsers()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable UserTable = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from AspNetUsers", con);
                adpAuctions.Fill(UserTable);
            }
            catch (DataException e)
            {
                throw e;
            }

            return UserTable;
        }

        public static void InsertAuction(int propertyId, DateTime starttime, DateTime endtime)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Auctions (PropertyID, StartTime, endTime) Values(@PropertyID,@StartTime,@EndTime)", con);

                //SqlCommand Cmd = new SqlCommand("Insert Into Auctions (PropertyID, StartTime, endTime) Values('"+propertyId+"',"+starttime+","+endtime+")", con);


                Cmd.Parameters.Add("@PropertyID", System.Data.SqlDbType.Int);
                Cmd.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime);
                Cmd.Parameters.Add("@EndTime", System.Data.SqlDbType.DateTime);


                Cmd.Parameters["@PropertyID"].Value = Convert.ToInt32(propertyId);
                Cmd.Parameters["@StartTime"].Value = Convert.ToDateTime(starttime);
                //Cmd.Parameters["@StartTime"].Value = DateTime.Now;
                Cmd.Parameters["@EndTime"].Value = Convert.ToDateTime(endtime);
                // Cmd.Parameters["@EndTime"].Value = DateTime.Now; 


                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static void GrantAdminToUse(string userid)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into AspNetUserRoles (Userid, Roleid) Values('" + userid + "','01')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string getUserRole(string userid)
        {

            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable roleid = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT Roleid from AspNetUserRoles where Userid = '" + userid + "'", con);
                adpAuctions.Fill(roleid);

            }
            catch (DataException e)
            {
                throw e;
            }

            foreach (DataRow row in roleid.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    if (cell != null)
                    {

                        return @cell.ToString();

                    }
                }


            }
            return "none";
        }

        public static newAddProppertyViewModel getProperty(int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable propertyId = new DataTable();
            newAddProppertyViewModel model = new newAddProppertyViewModel();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from Property where PropertyID = '" + id + "'", con);
                adpAuctions.Fill(propertyId);

            }
            catch (DataException e)
            {
                throw e;
            }

            foreach (DataRow row in propertyId.Rows)
            {
                model.PropertyID = Convert.ToInt32(row.ItemArray[0]);
                model.Address = row.ItemArray[1].ToString();
                model.OpeningBid = Convert.ToDouble(row.ItemArray[2]);
                model.Reserve = Convert.ToDouble(row.ItemArray[3]);
                model.Description = row.ItemArray[4].ToString();
                model.Documents = row.ItemArray[5].ToString();
                model.Location = row.ItemArray[6].ToString();

            }
            return model;
        }

        public static void deleteProperty(int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Delete FROM Property WHERE PropertyID = '" + id + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void editProperty(int id, newAddProppertyViewModel model)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("UPDATE Property SET Address = '" + model.Address + "', OpeningBid = " + model.OpeningBid + ", Description = '" + model.Description + "',Reserve='" + model.Reserve + "' ,Documents = '" + model.Documents + "', Location = '" + model.Location + "' WHERE PropertyID = '" + id + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void editAuction(int id, EditAuctionModel model)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("UPDATE Auctions SET PropertyID = '" + model.PropertyId + "', StartTime = '" + model.StartTime + "', endTime = '" + model.EndTime + "' WHERE AuctionID = '" + id + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static EditAuctionModel getAuction(int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable AuctionID = new DataTable();
            EditAuctionModel model = new EditAuctionModel();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from Auctions where AuctionID = '" + id + "'", con);
                adpAuctions.Fill(AuctionID);

            }
            catch (DataException e)
            {
                throw e;
            }

            foreach (DataRow row in AuctionID.Rows)
            {
                model.AuctionId = Convert.ToInt32(row.ItemArray[0]);
                model.PropertyId = Convert.ToInt32(row.ItemArray[1]);
                model.StartTime = Convert.ToDateTime(row.ItemArray[2]);
                model.EndTime = Convert.ToDateTime(row.ItemArray[3]); ;


            }
            return model;
        }



        public static void deleteAuction(int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Delete FROM Auctions WHERE AuctionID = '" + id + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable getUsersDisply()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable UserTable = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT u.Id, u.UserName, u.Email, u.PhoneNumber, r.RoleId from AspNetUsers u Left JOIN AspNetUserRoles r ON r.UserId = u.Id ", con);

                //SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT Id, UserName, Email, PhoneNumber from AspNetUsers", con);
                adpAuctions.Fill(UserTable);
            }
            catch (DataException e)
            {
                throw e;
            }

            return UserTable;
        }



        public static addUserRoleDisply getUserDisply(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable UserTable = new DataTable();
            addUserRoleDisply model = new addUserRoleDisply();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT Id, UserName, Email, PhoneNumber from AspNetUsers WHERE Id ='" + id + "'", con);
                adpAuctions.Fill(UserTable);
            }
            catch (DataException e)
            {
                throw e;
            }

            foreach (DataRow row in UserTable.Rows)
            {
                model.userId = row.ItemArray[0].ToString();
                model.UserName = row.ItemArray[1].ToString();
                model.Email = row.ItemArray[2].ToString();
                model.Selnumber = row.ItemArray[3].ToString();


            }
            return model;

        }


        public static void revokeRole(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Delete FROM AspNetUserRoles WHERE UserId = '" + id + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable getPaths(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable Paths = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT ImagePath from Images2 WHERE PropertyID ='" + id + "'", con);
                adpAuctions.Fill(Paths);
            }
            catch (DataException e)
            {
                throw e;
            }


            return Paths;
        }

        public static DataTable getLogoPaths(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable Paths = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT Path from Logos WHERE PropertyID ='" + id + "'", con);
                adpAuctions.Fill(Paths);
            }
            catch (DataException e)
            {
                throw e;
            }


            return Paths;
        }


        public static void insertImage(string Path, int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Images2 (PropertyID, ImagePath) Values('" + id + "','" + Path + "')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
        }

        public static void insertLogo(string Path, int id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Logos (PropertyID, Path) Values('" + id + "','" + Path + "')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
        }

        public static DataTable getDeposit(string id)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            DataTable deposit = new DataTable();

            try
            {
                SqlDataAdapter adpAuctions = new SqlDataAdapter("SELECT * from Deposits WHERE userID ='" + id + "'", con);
                adpAuctions.Fill(deposit);
            }
            catch (DataException e)
            {
                throw e;
            }


            return deposit;
        }


        public static void depositRefunded(string user)
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;

            try
            {
                SqlCommand Cmd = new SqlCommand("Delete FROM Deposits WHERE userID = '" + user + "'", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }



        }


        public static void PlaceBid(int AuctionID, string UserID,double bid )
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings[db].ConnectionString;
            con.ConnectionString = path;
            try
            {
                SqlCommand Cmd = new SqlCommand("Insert Into Bids (AuctionID, UserID, bid ) Values('" + AuctionID + "','" + UserID + "','" + bid + "')", con);

                con.Open();
                int RowsAffected = Cmd.ExecuteNonQuery();

                // close connection when done
                con.Close();
            }
            catch (DataException e)
            {

                throw e;

            }
        }

    }
}