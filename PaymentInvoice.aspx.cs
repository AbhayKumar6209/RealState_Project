using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstate.DataBase;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RealEstate
{
    public partial class PaymentInvoice : Page
    {
        #region _qe

        DbLayer dbl = new DbLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string InvoiceNo = Convert.ToString(Request.QueryString["InvoiceNo"]);
                string CompanyMobile = "", CompanyEmail = "", CompanyName = "", CompanyAddress = "";
                string RecieptNo = "", ReceiptDate = "", CustomerId = "", BookingId = "", ProjectName = "", PlotNo = "", Block = "", Area = "", BuyerName = "", BuyerMob = "", BuyerAddr = "", City = "", State = "", PlotType = "", PlotRate = "", TotalAmnt = "", PaidAmnt = "", Discount = "", DepositedAmnt = "", WordRs = "", PayAs = "", DueAmnt = "", PayMode = "", PayDate = "", ID = "", PlanType = "";
                try
                {

                    #region Variables Values

                    CompanyName = "DREAM IT SOLUTION REAL ESTATE";
                    CompanyAddress = "512/27, GOMATI NAGAR, LUCKNOW, UTTAR PRADESH 226010";
                    CompanyMobile = "9876543210";
                    CompanyEmail = "info@dreamitsolution.org";
                    RecieptNo = "MSPR1530 / MSPR1530";
                    ReceiptDate = DateTime.Now.ToString("dd/MM/yyyy");
                    CustomerId = "MSPRC000494";
                    BookingId = "MSPR00000684";
                    ProjectName = "R.S. GREEN CITY";
                    PlotNo = "F-15";
                    Block = "F";
                    Area = "50.00 Gaj (450 Sq.ft)";
                    BuyerName = "VIRENDRA KUMAR SAHU";
                    BuyerMob = "9876543210";
                    BuyerAddr = "VILL & PO SAJETI DISTT KANPUR NAGAR";
                    City = "Lucknow";
                    State = "UP";
                    PlotType = "Normal";
                    PlotRate = "7000.00";
                    TotalAmnt = "350000.00";
                    PaidAmnt = "100000.00";
                    Discount = "0.00";
                    DepositedAmnt = "100000.00";
                    WordRs = "One Lakh";
                    PayAs = "Booking Amount";
                    DueAmnt = "250000";
                    PayMode = "Cash";
                    PayDate = DateTime.Now.ToString("dd/MM/yyyy");
                    ID = "MSPRB000001";
                    PlanType = "Full Payment";

                    #endregion Variables Values

                    if (string.IsNullOrEmpty(Page.Title))
                    {
                        Page.Title = "Payment Invoice";
                    }

                    Document doc = new Document(iTextSharp.text.PageSize.A4);
                    PdfPTable tableLayout = new PdfPTable(12);
                    MemoryStream memStream = new MemoryStream();
                    PdfWriter writer = PdfWriter.GetInstance(doc, memStream);
                    float[] headers = { 6, 16, 8, 8, 8, 7, 9, 8, 8, 11, 9, 8 };
                    // float[] headers = { 6, 10, 9, 18, 8, 7, 9, 8, 8, 11, 9, 8, 8 };
                    tableLayout.SetWidths(headers);
                    tableLayout.WidthPercentage = 100;

                    string imageFilePath = Server.MapPath(".") + "/HomeAssets/logo.png";
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                    jpg.ScaleToFit(80f, 150f);

                    #region Duplicate Office Copy

                    #region Header

                    tableLayout.AddCell(new PdfPCell((jpg)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthTop = 0, PaddingTop = 10, PaddingLeft = 10, BorderWidthLeft = 0, BorderWidthBottom = 0, Colspan = 2, Rowspan = 4 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 7, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Duplicate (Office Copy)", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0, PaddingTop = 5, PaddingLeft = 30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(CompanyName, new Font(Font.GetFamilyIndex("HELVETICA"), 14, 1))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(CompanyAddress.ToUpper(), new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Call Us: " + CompanyMobile + ", Email ID: " + CompanyEmail, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0, PaddingTop = -2, PaddingBottom = 8 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("PAYMENT RECIEPT", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1, BaseColor.WHITE))) { Colspan = 4, BackgroundColor = BaseColor.BLACK, PaddingBottom = 5, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });

                    #endregion Header

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Receipt No: " + RecieptNo, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 5, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Receipt Date: " + ReceiptDate, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });


                    #region Company Details

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Company Name: " + CompanyName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Customer Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(CustomerId, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Booking Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BookingId, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });



                    tableLayout.AddCell(new PdfPCell(new Phrase("Project: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(ProjectName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot No: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlotNo, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });



                    tableLayout.AddCell(new PdfPCell(new Phrase("Block: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(Block, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Area: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(Area, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 1, PaddingLeft = -10 });

                    #endregion Company Details

                    #region Buyer Details


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))){ Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Buyer's Name: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Mobile No.: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerMob, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Adress: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerAddr, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 10, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("City: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(City, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("State: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(State, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot Type: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlotType, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot Rate: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + PlotRate + "/ Gaj", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Total Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + TotalAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Paid Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + PaidAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Discount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + Discount, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Deposited Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + DepositedAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("In Words(Rs.): ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(WordRs + " Only", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 10, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay As: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayAs, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Due Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + DueAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay Mode: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayMode, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay Date: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayDate, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(ID, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plan Type: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlanType, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 1, PaddingLeft = -10 });


                    #endregion Buyer Details

                    #region Description

                    //tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("NOTE-", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("1– The receipt is subject to realization of cash,cheque and DD.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("2– This is merely a receipt against the cheque/draft/pay order recieved by the company based on information\r\nfurnished by the applicant in theapplication and the allotment pursuant thereto is purely provisional and does not\r\nentitile the applicant to claim any right, title or interest of any nature whosoever over the land/Property.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("3– In case the cheque comprising booking amount is dishonored due to any reason whatsoever the applicant shall\r\nbe deemed to be null and void and the allotment, if any, shall stand automatically cancelled/revoked/withdrawn\r\nwithout any notice to the applicant.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("4– Full Payment Plan-All Payment should be deposited within 30 days of Booking date of Plot, other wise Plot will\r\nhave cancelled after deduction of 20 % Deposited Amount as D.E/Levy, etc..\r\n", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("5– This is computer generated receipt.No stamp required.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthBottom = 0, PaddingTop = 30 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("(Authorised Signatory)", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthBottom = 0, PaddingTop = 30 });

                    #endregion Description

                    #endregion Duplicate Office Copy


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthBottom = 0, PaddingBottom = 120 });

                    /*doc.NewPage();
                    tableLayout.KeepTogether = false;
                    tableLayout.SplitRows = true;
                    tableLayout.SplitLate = true;*/

                    #region Duplicate Customer Copy


                    #region Header

                    jpg.ScaleToFit(80f, 150f);

                    tableLayout.AddCell(new PdfPCell((jpg)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthTop = 0, PaddingTop = 10, PaddingLeft = 10, BorderWidthLeft = 0, BorderWidthBottom = 0, Colspan = 2, Rowspan = 4 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 6, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Duplicate (Customer Copy)", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 4, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0, PaddingTop = 5, PaddingLeft = 30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(CompanyName, new Font(Font.GetFamilyIndex("HELVETICA"), 14, 1))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(CompanyAddress.ToUpper(), new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Call Us: " + CompanyMobile + ", Email ID: " + CompanyEmail, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderWidthBottom = 0, PaddingTop = -2 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("PAYMENT RECIEPT", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1, BaseColor.WHITE))) { Colspan = 4, BackgroundColor = BaseColor.BLACK, PaddingBottom = 5, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });

                    #endregion Header

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Receipt No: " + RecieptNo, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 5, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Receipt Date: " + ReceiptDate, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 4, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });


                    #region Company Details

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 12, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthBottom = 0 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Company Name: " + CompanyName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Customer Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(CustomerId, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Booking Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BookingId, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });



                    tableLayout.AddCell(new PdfPCell(new Phrase("Project: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(ProjectName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot No: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlotNo, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });



                    tableLayout.AddCell(new PdfPCell(new Phrase("Block: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(Block, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Area: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(Area, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 1, PaddingLeft = -10 });

                    #endregion Company Details

                    #region Buyer Details


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Buyer's Name: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerName, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Mobile No.: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerMob, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Adress: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(BuyerAddr, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 10, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("City: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(City, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("State: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(State, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot Type: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlotType, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plot Rate: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + PlotRate + "/ Gaj", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Total Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + TotalAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Paid Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + PaidAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Discount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + Discount, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Deposited Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + DepositedAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("In Words(Rs.): ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(WordRs + " Only", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 10, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay As: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayAs, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Due Amount: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("Rs. " + DueAmnt, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay Mode: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayMode, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Pay Date: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PayDate, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase("Id: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(ID, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -30 });

                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("Plan Type: ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 2, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(PlanType, new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 3, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0, PaddingLeft = -10 });


                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 1, PaddingLeft = -10 });


                    #endregion Buyer Details

                    #region Description

                    //tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("NOTE-", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });

                    tableLayout.AddCell(new PdfPCell(new Phrase("1– The receipt is subject to realization of cash,cheque and DD.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("2– This is merely a receipt against the cheque/draft/pay order recieved by the company based on information\r\nfurnished by the applicant in theapplication and the allotment pursuant thereto is purely provisional and does not\r\nentitile the applicant to claim any right, title or interest of any nature whosoever over the land/Property.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("3– In case the cheque comprising booking amount is dishonored due to any reason whatsoever the applicant shall\r\nbe deemed to be null and void and the allotment, if any, shall stand automatically cancelled/revoked/withdrawn\r\nwithout any notice to the applicant.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("4– Full Payment Plan-All Payment should be deposited within 30 days of Booking date of Plot, other wise Plot will\r\nhave cancelled after deduction of 20 % Deposited Amount as D.E/Levy, etc..\r\n", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("5– This is computer generated receipt.No stamp required.", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 0))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthBottom = 0 });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthBottom = 0, PaddingTop = 30 });
                    tableLayout.AddCell(new PdfPCell(new Phrase("(Authorised Signatory)", new Font(Font.GetFamilyIndex("HELVETICA"), 10, 1))) { Colspan = 12, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthRight = 0, HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthBottom = 0, PaddingTop = 30 });

                    #endregion Description


                    #endregion Duplicate Customer Copy


                    #region Final Step For Document

                    doc.Open(); doc.Add(tableLayout); doc.Close();
                    Response.ClearContent(); Response.ClearHeaders(); Response.ContentType = "application/pdf";
                    Response.BinaryWrite(memStream.ToArray()); Response.Flush();
                    Response.Clear(); doc.Dispose(); memStream.Dispose();

                    #endregion Final Step For Document
                }
                catch (Exception exc)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + exc.Message + "');", true);
                }
            }

            #endregion _qe
        }
    }

    #region _qe

    public class PDFFooter : PdfPageEventHelper
    {

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            /*base.OnEndPage(writer, document);

            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(15);

            float[] headers = { 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 }; ;
            tabFot.SetWidths(headers);
            tabFot.WidthPercentage = 100;

            PdfPCell cell;
            tabFot.TotalWidth = 350F;

            //----Footer Start---------------------------
            tabFot.AddCell(new PdfPCell(new Phrase("Declaration", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 7 });
            tabFot.AddCell(new PdfPCell(new Phrase("For " + System.Web.HttpContext.Current.Session["company_name"].ToString() + "", new Font(Font.GetFamilyIndex("HELVETICA"), 7, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 15 });
            tabFot.AddCell(new PdfPCell(new Phrase("We declare that this invoice showsthe actual price of the goods described and than all particulars are true and correct.", new Font(Font.GetFamilyIndex("HELVETICA"), 7, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_JUSTIFIED, Colspan = 7 });
            //tabFot.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 8 });
            //tabFot.AddCell(new PdfPCell(new Phrase("2. Interest @24% p.a. will be charged if the bill is not paid within 30 days.", new Font(Font.GetFamilyIndex("HELVETICA"), 7, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 7 });

            //tabFot.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 8 });
            //tabFot.AddCell(new PdfPCell(new Phrase("3. No Guarantee,No Replacement,No Exchange.", new Font(Font.GetFamilyIndex("HELVETICA"),7, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 7 });
            //tabFot.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan =8 });
            //tabFot.AddCell(new PdfPCell(new Phrase("4. Our Responsbility cases once the goods are handled over to carrying agency.", new Font(Font.GetFamilyIndex("HELVETICA"), 7, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 8 });
            tabFot.AddCell(new PdfPCell(new Phrase(" \n\n\n Authorised Signatory\n\n", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 15 });
            //tabFot.AddCell(new PdfPCell(new Phrase("Bank Name:  ICICI Bank Aminabad,Lukcnow | Current A/C No.103305002067 ,103305500547 |IFSC Code:ICIC0001033", new Font(Font.GetFamilyIndex("HELVETICA"),7, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 15 });
            //tabFot.AddCell(new PdfPCell(new Phrase("Bank Name: Bank of Baroda | Current A/C No: 00510200000115 |IFSC Code: BARB0AMINAB ", new Font(Font.GetFamilyIndex("HELVETICA"), 7, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 15 });

            tabFot.AddCell(new PdfPCell(new Phrase("This is a Computer Generated Invoice.", new Font(Font.GetFamilyIndex("HELVETICA"), 6, 0))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 15 });
            //tabFot.AddCell(new PdfPCell(new Phrase("Signature:", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 7, FixedHeight = 50 });
            //tabFot.AddCell(new PdfPCell(new Phrase("Name of the Signatory ", new Font(Font.GetFamilyIndex("HELVETICA"), 7,0))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 8, FixedHeight = 50 });

            //tabFot.AddCell(new PdfPCell(new Phrase("Designation/Status:", new Font(Font.GetFamilyIndex("HELVETICA"), 7,0))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 15 });

            //tabFot.AddCell(new PdfPCell(new Phrase("Electronic Reference Number	: " + System.Web.HttpContext.Current.Session["InvoiceNo"].ToString(), new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 7 });
            //tabFot.AddCell(new PdfPCell(new Phrase("Date :"+System.DateTime.Now.ToShortDateString(), new Font(Font.GetFamilyIndex("HELVETICA"), 7,0))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 8 });


            //----Footer End---------------------------
            cell = new PdfPCell(new Phrase("", new Font(Font.GetFamilyIndex("HELVETICA"), 9, 1))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Colspan = 7 };
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 30, 100, writer.DirectContent);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);


            PdfPTable pdfTab = new PdfPTable(2);

            PdfPCell pdfCell1 = new PdfPCell();

            PdfPCell pdfCell3 = new PdfPCell();
            String text = "Page " + writer.PageNumber + " of ";

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(20));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 10);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(20));
            }



            pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;




            pdfCell1.Border = 0;

            pdfCell3.Border = 0;


            pdfTab.AddCell(pdfCell1);

            pdfTab.AddCell(pdfCell3);


            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;


            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent); */




        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 10);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 10);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }

    }

    #endregion _qe

}