Imports System.Net

Public Class ClientPdf

    Public Shared Sub Main(args() As String)
        Dim customerKey As String = "PUT_YOUR_CUSTOMER_KEY_HERE"
        Dim secretPhrase As String = "" REM leave secret phrase empty, If Not needed

        Dim options As New Dictionary(Of String, String)
        REM mandatory parameter
        options.Add("url", "https://www.google.com")
        REM  all next parameters are optional, see our website to PDF API guide for more details
        options.Add("paper", "letter")
        options.Add("orientation", "portrait")
        options.Add("media", "print")
        options.Add("bg", "nobg")
        options.Add("delay", "2000")
        options.Add("scale", "50")

        Dim sm As ScreenshotMachine = New ScreenshotMachine(customerKey, secretPhrase)
        Dim pdfApiUrl As String = sm.GeneratePdfApiUrl(options)

        REM save PDF file
        Dim client As New WebClient()
        Dim output As String = "output.pdf"
        client.DownloadFile(pdfApiUrl, output)
        Console.WriteLine("PDF saved as " + output)
    End Sub

End Class
