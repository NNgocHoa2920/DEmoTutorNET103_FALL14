using System.Data.SqlClient;

namespace DemoBuoi1.Models
{
    public class SinhVienDAL
    {
        //khởi tạo chuỗi kết nối đến sql
        string connectionString = "Server=NGUYEN_NGOC_HOA\\HOANN;Database=ADO_Tutor;Trusted_Connection=True;TrustServerCertificate=True";

        //ĐỐI TƯỢNG SqlConnection NÓ CÓI 2 TRẠNG THÁI: OPEN VÀ CLOSE, MẶC ĐỊNH LÀ CLOSE
        //VẬY MỖI KHI KẾT NỐI VS SQL THÌ PHẢI OPEN
        //sAU KHI MÀ KẾT NỐI XONG THÌ CLOSE, ĐẢM KIỂM SOASTR ĐƯỢC TRANG THÁI CỦA NÓ
        //Hiển thị toàn bộ dữ liệu của sinh viên
        public IEnumerable<SinhVien> GetAllSinhVien()
        {
            //var: kiểu dữ liệu, khi khai báo k cần xác định rõ xem nó là kiểu dữ liệu gì, 
            //thích hợp dùng cho khai báo đối tượgh
            var listSV = new List<SinhVien>();
            //using được sử dụng theo 2 cách
            /*
             * cách 1: đẻ khai báo thư viện, poackget..
             * cách 2: đảm bảo rằng 1 hya nhiều câu lệnh sẽ được dừng tự động sau khi hoàn thành khối mã
             */
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM SINHVIEN";
                //SQL COMMAND LÀ ĐỐI TƯỢNG DÙNG ĐỂ THỰC THI CÂU LỆNH SQL
                //có 2 tham số truyền vào: câu lệnh và chuỗi kn
                SqlCommand cmd = new SqlCommand(query, con);
                //sqldatareader dùng để đọc dữ liệu từ cở sở dữ liệu =< chỉ đọc
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SinhVien sv = new SinhVien();
                    sv.Id = Convert.ToInt32(reader["ID"]);
                    sv.Name = reader["Name"].ToString();
                    sv.Gender = reader["Gender"].ToString();
                    listSV.Add(sv);

                }
                con.Close();

            }

            return listSV;
        }

        //thêm sinh viên
        public void AddSinhVien(SinhVien sinhVien)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO SINHVIEN(ID, NAME, GENDER) VALUES(@ID, @NAME,@GENDER)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@Id", sinhVien.Id);
                cmd.Parameters.AddWithValue("@Name", sinhVien.Name);
                cmd.Parameters.AddWithValue("@Gender", sinhVien.Gender);
                cmd.ExecuteNonQuery(); // để thực thi các câu lệnh như insert, update, delete
                con.Close();
            }

        }
    }
}
