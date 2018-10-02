using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace ASM_1
{
    class DanhSachSinhVien

    {
        private const string PHONE_FORMAT = "^\\d{11}$";
        private const string DATE_FORMAT = "dd/MM/yyyy";

        private List<SinhVien> danhSachSinhVien = null;

        public List<SinhVien> DanhSach
        {
            get { return danhSachSinhVien; }
            set { danhSachSinhVien = value; }
        }

        public DanhSachSinhVien()
        {

        }
        public void XemDanhSachSinhVien()
        {
            if (danhSachSinhVien == null)
            {
                Console.WriteLine("Khong co sinh vien nao.");
            }
            else
            {
                Console.WriteLine("Danh sach sinh vien:");
                foreach (SinhVien s in danhSachSinhVien)
                {
                    s.XemThongTin();
                }
            }


        }

        public int TimSinhVienTheoMa(string maSV)
        {
            int output = -1;
            if (danhSachSinhVien == null)
            {
                return -1;
            }
            for (int i = 0; i < danhSachSinhVien.Count; i++)
            {
                SinhVien s = danhSachSinhVien.ElementAt(i);
                if (s.MaSV.Equals(maSV))
                {
                    output = i;
                    break;
                }
            }
            return output;
        }

        public void TimSinhVien()
        {
            if (danhSachSinhVien == null)
            {
                Console.WriteLine("Khong co sinh vien nao.");
                return;
            }
            Console.WriteLine("Nhap ma SV can tim:");
            string maSV = (Console.ReadLine()).Trim();
            maSV = maSV.ToUpper();
            int index = -1;
            index = TimSinhVienTheoMa(maSV);
            if (index == -1)
            {
                Console.WriteLine("Khong tim thay sinh vien co ma so :" + maSV);
            }
            else
            {
                danhSachSinhVien.ElementAt(index).XemThongTin();
            }
        }

        public void ThemSinhVien()
        {
            if(danhSachSinhVien != null)
            {
                if(danhSachSinhVien.Count == 50)
                {
                    Console.WriteLine("Danh sach da day. Khong the them!");
                    return;
                }
            }
            string maSV;
            int index = -1;
            do
            {
                Console.WriteLine("Nhap ma SV: ");
                maSV = (Console.ReadLine()).Trim();
                maSV = maSV.ToUpper();
                index = TimSinhVienTheoMa(maSV);
                if (index > -1)
                {
                    Console.WriteLine("Sinh vien co ma nay da ton tai, vui long nhap ma khac.");
                }
            } while (index > -1);

            Console.WriteLine("Nhap Ho ten:");
            string hoTen = (Console.ReadLine()).Trim();
            bool check;
            DateTime ngaySinh= new DateTime();
            do
            {
                check = false;
                try
                {
                    Console.WriteLine("Nhap Ngay Sinh (ngay/thang/nam):");
                    string ngaySinhString = (Console.ReadLine()).Trim();
                    ngaySinh = DateTime.ParseExact(ngaySinhString, DATE_FORMAT, null);
                    check = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sai dinh dang ngay, vui long nhap lai.");
                }
            } while (check==false);
            
            

            Console.WriteLine("Nhap Dia chi:");
            string diaChi = (Console.ReadLine()).Trim();

            string dienThoai;
            do
            {
                check = false;
                Console.WriteLine("Nhap Dien thoai:");
                dienThoai = (Console.ReadLine()).Trim();
                check = Regex.IsMatch(dienThoai, PHONE_FORMAT);
                if (!check)
                {
                    Console.WriteLine("So dien thoai phai la so, va co 11 chu so, vui long nhap lai.");
                }
            } while (check == false);

            SinhVien s = new SinhVien(maSV, hoTen, ngaySinh, diaChi, dienThoai);
            if (danhSachSinhVien == null)
            {
                danhSachSinhVien = new List<SinhVien>();
            }
            danhSachSinhVien.Add(s);
            Console.WriteLine("Them sinh vien thanh cong.");
        }

        public void CapNhapThongTinSinhVien()
        {
            if (danhSachSinhVien == null)
            {
                Console.WriteLine("Khong co sinh vien nao.");
                return;
            }
            Console.WriteLine("Nhap ma SV can cap nhap:");
            string maSV = (Console.ReadLine()).Trim();
            maSV = maSV.ToUpper();
            int index = TimSinhVienTheoMa(maSV);
            if (index < 0)
            {
                Console.WriteLine("Khong tim thay sinh vien co ma so :" + maSV);
            }
            else
            {
                Console.WriteLine("Nhap Ho ten:");
                string hoTen = (Console.ReadLine()).Trim();
                danhSachSinhVien.ElementAt(index).HoTen = hoTen;
                bool check;
                DateTime ngaySinh = new DateTime();
                do
                {
                    check = false;
                    try
                    {
                        Console.WriteLine("Nhap Ngay Sinh (ngay/thang/nam):");
                        string ngaySinhString = (Console.ReadLine()).Trim();
                        ngaySinh = DateTime.ParseExact(ngaySinhString, DATE_FORMAT, null);
                        check = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Sai dinh dang ngay, vui long nhap lai.");
                    }
                } while (check == false);
                danhSachSinhVien.ElementAt(index).NgaySinh = ngaySinh;
                Console.WriteLine("Nhap Dia chi:");
                string diaChi = (Console.ReadLine()).Trim();
                danhSachSinhVien.ElementAt(index).DiaChi = diaChi;
                string dienThoai;
                do
                {
                    check = false;
                    Console.WriteLine("Nhap Dien thoai:");
                    dienThoai = (Console.ReadLine()).Trim();
                    check = Regex.IsMatch(dienThoai, PHONE_FORMAT);
                    if (!check)
                    {
                        Console.WriteLine("So dien thoai phai la so, va co 11 chu so, vui long nhap lai.");
                    }
                } while (check == false);
                danhSachSinhVien.ElementAt(index).DienThoai = dienThoai;
                Console.WriteLine("Cap nhap thong tin thanh cong.");
            }
        }
    }
}
