using GrapeCity.Documents.Pdf;
using GrapeCity.Documents.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Brushes = System.Drawing.Brushes;
using SystemFonts = System.Drawing.SystemFonts;

namespace TestPdfApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    int numIter = 10;
    int boxHeight = 50;

        System.Drawing.Pen line = new System.Drawing.Pen(System.Drawing.Color.Blue, 0.2F);

    private void CreateC1PdfDoc(object sender, RoutedEventArgs e) {
      C1.C1Pdf.C1PdfDocument pdfDoc = new C1.C1Pdf.C1PdfDocument();
      int yOffset = 10;
      string text = "The quick brown fox jumps over the lazy dog";
      for (int i = 0; i <= numIter; i++) {
        RectangleF rect = new RectangleF(10, yOffset + i * (boxHeight+5), 200, boxHeight);
        pdfDoc.DrawRectangle(line, rect);
        System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
        pdfDoc.DrawString(text, font, Brushes.Black, rect);
      }

      pdfDoc.Save("C1Pdf.pdf");
    }


    private void CreateGrapeCityPdfDoc(object sender, RoutedEventArgs e) {
      GcPdfDocument pdfDoc;
      GrapeCity.Documents.Pdf.Page currentPage;
      GcPdfGraphics pdfGraphics;
      pdfDoc = new GcPdfDocument();
      currentPage = pdfDoc.NewPage();
      pdfGraphics = currentPage.Graphics;

      TextFormat textFormat = new TextFormat();
      int yOffset = 10;
      string text = "The quick brown fox jumps over the lazy dog";
      for (int i = 0; i <= numIter; i++) {
        RectangleF rect = new RectangleF(10, yOffset + i * (boxHeight + 5), 200, boxHeight);
        pdfGraphics.DrawString(text, textFormat, rect);
      }

      pdfDoc.Save("GrapeCityPdf.pdf");

    }
  }
}
