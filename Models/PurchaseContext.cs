using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class PurchaseContext
    {
        public string connectionString { get; set; }

        public PurchaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<Purchase> getPurchaseDetails()
        {
            List<Purchase> list = new List<Purchase>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select billNo, supplier.supplierName, product.name, quantity, unitPrice,purchaseDate from purchaseBill join Supplier on Supplier.id = purchaseBill.supplierId join Product on Product.id = purchaseBill.productId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Purchase()
                        {
                            billNo = reader["billNo"].ToString(),
                            supplierName = reader["supplierName"].ToString(),
                            productName = reader["name"].ToString(),
                            quantity = Convert.ToInt32(reader["quantity"]),
                            unitPrice = Convert.ToDouble(reader["unitPrice"]),
                            purchaseDate = Convert.ToDateTime(reader["purchaseDate"])
                        });
                    }
                    conn.Close();
                }

            }
            return list;

        }
        public void insert(Purchase obj)
        {
            String insertQuery = "insert into PurchaseBill(billNo,supplierId,PurchaseId,quantity,unitPrice) values('" + obj.billNo + "','" + obj.supplierName + "','" + obj.productName + "','" + obj.quantity + "','" + obj.unitPrice + "')";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

    }
}
