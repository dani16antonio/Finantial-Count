using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fcount.Droid;
using Xamarin.Forms;
using Fcount.viewmodels.utils;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

[assembly: Dependency(typeof(PDFManagement))]
namespace Fcount.Droid
{
    public class PDFManagement : Object, ICreatePDF
    {
        public async void Create()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            graphics.DrawString($"Bienvenido a Finantial Count." +
                $"{System.Environment.NewLine}Cotización", font, PdfBrushes.Black, new PointF(0, 0));
            //TODO: Continue this
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            SaveAndroid androidSave = new SaveAndroid();
            await androidSave.SaveAndView("Output2.pdf", "application/pdf", stream);
        }
    }
}