using iTextSharp.text;
using iTextSharp.text.pdf;
using NUnit.Framework;
using System;
using System.IO;

namespace Tutorial
{
    class ITextPDFTest
    {
        [Test]
        public void HandlePDFTest()
        {
            using (Document document = new Document())
            {
                //try
                //{
                //    FileStream fs = new FileStream(@"test1.pdf", FileMode.Create);
                //    PdfWriter.GetInstance(document, fs);

                //    Paragraph p = new Paragraph("Hello World!", new Font(Font.FontFamily.COURIER, 20f));
                //    document.Open();
                //    document.Add(p);//加入文章段落
                //    document.AddTitle("Tutorial-Hello World!");//文件標題
                //    document.AddAuthor("einboch");//文件作者



                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //finally
                //{
                //    if (document.IsOpen()) document.Close();
                //}

                using (var ms = new MemoryStream())
                {
                    using (var reader = new PdfReader(@"test1.pdf"))
                    {
                        using (var stamper = new PdfStamper(reader, ms))
                        {
                            //取得表單
                            var form = stamper.AcroFields;
                            //套入文字
                            form.SetField("Name", "王小明");
                            //套入顏色
                            var color = "#FF0000";   //紅色
                            var baseColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(color));
                            form.SetFieldProperty("Name", "textcolor", baseColor, null);
                        }
                    }
                }
            }

        }
    }
}
