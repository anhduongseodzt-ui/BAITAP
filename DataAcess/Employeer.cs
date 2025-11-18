using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataAcess.STRACT;
using OfficeOpenXml;

namespace DataAcess
{
    public class Employeer
    {
        List<DataAcess.STRACT.Employeer_Struct> empl = new List<STRACT.Employeer_Struct>();
        public int Employeer_Insert(string EmployeerCodeInput, string EmployeerNameInput, DateTime StartDateInput)
        //ham them ,sua,xoa tra ve thanh cong hay that bai ,try de in xem loi j 

        {

            var ketqua = 0;
            try
            {
                //bb1:ktra du lieu dau vao
                if (!common.ValiDateInput.CheckValueInputNumber(EmployeerCodeInput) || !common.ValiDateInput.CheckXSSInput(EmployeerCodeInput))
                {
                    ketqua = (int)EmployeerEnum.MASV_K_HOP_LE;
                    return ketqua;

                }
                if (!common.ValiDateInput.CheckValueInputString(EmployeerNameInput) || !common.ValiDateInput.CheckXSSInput(EmployeerNameInput))
                {
                    ketqua = (int)EmployeerEnum.TEN_K_HOP_LE;
                    return ketqua;

                }
                //B2:check trung 
                //C1: 
                var isDuplicate = false;
                for (int i = 0; empl.Count > 0; i++)
                {
                    if (empl[i].EmployeerCode == EmployeerCodeInput)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    ketqua = (int)EmployeerEnum.DATONTAI;
                    return ketqua;
                }
                //B3 them vao danh sach
                var new_emp = new Employeer_Struct();
                new_emp.EmployeerCode = EmployeerCodeInput;
                new_emp.EmployeerName = EmployeerNameInput;
                new_emp.StartDate = StartDateInput;
                empl.Add(new_emp);
                ketqua = (int)EmployeerEnum.THANHCONG;


            }
            catch (Exception ex)
            {
                throw new Exception("loi :" + ex.Message);
                //throw ex;
            }
            return ketqua;
        }

        public string Employeer_Insert_FromExcelFile(string filePath)
        {
            var ketqua = string.Empty;
            var errName = new StringBuilder();
            try
            {

                ExcelPackage.License.SetNonCommercialPersonal("tran van duong");
               // ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // lấy sheet đầu tiên
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    //row hang
                    for (int row = 2; row <= rowCount; row++)
                    {

                        var code = worksheet.Cells[row, 1].Text;
                        var name = worksheet.Cells[row, 2].Text;
                        var startDate = worksheet.Cells[row, 3].Text;

                        if (!common.ValiDateInput.CheckValueInputString(code) || !common.ValiDateInput.CheckXSSInput(code))
                        {
                            errName.Append("code o hang :" + row + " |cot ow hang 1 k hop le");
                            continue;
                        }
                        if (!common.ValiDateInput.CheckValueInputString(name) || !common.ValiDateInput.CheckXSSInput(name))
                        {
                            errName.Append("code o hang :" + row + " |cot ow hang 2 k hop le");
                            continue;
                        }
                        //if (!common.ValiDateInput.CheckValueInputString(name) || !common.ValiDateInput.CheckXSSInput(name))
                        //{
                        //    errName.Append("code o hang :" + row + " |cot ow hang 2 k hop le");
                        //    continue;
                        //}
                        if (!DateTime.TryParse(startDate, out DateTime dt))
                        {
                            errName.Append("code o hang :" + row + " |cot ow hang 3 k hop le");
                            continue;
                        }

                        //if (!common.ValiDateInput.CheckValueInputNumber(startDate) || !common.ValiDateInput.CheckXSSInput(startDate))
                        //{
                        //    errName.Append("code o hang :" + row + " |cot ow hang 3 k hop le");
                        //    continue;
                        //}

                    }
                    Console.WriteLine();
                }
                if (errName.Length > 0)
                {
                    return errName.ToString();
                }

            }


            catch (Exception ex)
            {

                throw ex;

            }
            return ketqua;
        }
    }

}
