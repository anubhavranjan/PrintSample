using PrintSample.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing;
using Windows.UI.Xaml.Printing;
using Xamarin.Forms;

[assembly: Dependency(typeof(PrintReceiptUwp))]
namespace PrintSample.UWP
{
    public class PrintReceiptUwp : IPrintReceipt
    {

        PrintManager printmgr = PrintManager.GetForCurrentView();
        PrintDocument PrintDoc = null;
        PrintDocument printDoc;
        PrintTask Task = null;
        Windows.UI.Xaml.Controls.WebView ViewToPrint = new Windows.UI.Xaml.Controls.WebView();
        public PrintReceiptUwp()
        {
            printmgr.PrintTaskRequested += Printmgr_PrintTaskRequested;
        }

        public async void Print(string content)
        {
            ViewToPrint.NavigateToString(content);
            if (PrintDoc != null)
            {
                printDoc.GetPreviewPage -= PrintDoc_GetPreviewPage;
                printDoc.Paginate -= PrintDoc_Paginate;
                printDoc.AddPages -= PrintDoc_AddPages;
            }
            this.printDoc = new PrintDocument();
            try
            {
                printDoc.GetPreviewPage += PrintDoc_GetPreviewPage;
                printDoc.Paginate += PrintDoc_Paginate;
                printDoc.AddPages += PrintDoc_AddPages;

                bool showprint = await PrintManager.ShowPrintUIAsync();

            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.ToString());
            }
            PrintDoc = null;
            GC.Collect();

        }


        private void Printmgr_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            var deff = args.Request.GetDeferral();
            Task = args.Request.CreatePrintTask("Invoice", OnPrintTaskSourceRequested);

            deff.Complete();

        }
        async void OnPrintTaskSourceRequested(PrintTaskSourceRequestedArgs args)
        {
            var def = args.GetDeferral();
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                args.SetSource(printDoc.DocumentSource);
            });
            def.Complete();
        }

        private void PrintDoc_AddPages(object sender, AddPagesEventArgs e)
        {
            printDoc.AddPage(ViewToPrint);
            printDoc.AddPagesComplete();
        }

        private void PrintDoc_Paginate(object sender, PaginateEventArgs e)
        {
            PrintTaskOptions opt = Task.Options;
            printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
        }

        private void PrintDoc_GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            printDoc.SetPreviewPage(e.PageNumber, ViewToPrint);
        }
    }

}