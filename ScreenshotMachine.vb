Imports System.Net
Imports System.Text
Imports System.Security.Cryptography

Public Class ScreenshotMachine

    Private customerKey As String
    Private secretPhrase As String
    Private screenshotApiBaseUrl As String = "https://api.screenshotmachine.com/?"
    Private pdfApiBaseUrl As String = "https://pdfapi.screenshotmachine.com/?"

    Public Sub New(ByVal customerKey As String, ByVal secretPhrase As String)
        Me.customerKey = customerKey
        Me.secretPhrase = secretPhrase
    End Sub

    Public Function GeneratePdfApiUrl(ByVal options As Dictionary(Of String, String)) As String
        Return GenerateUrl(pdfApiBaseUrl, options)
    End Function

    Public Function GenerateScreenshotApiUrl(ByVal options As Dictionary(Of String, String)) As String
        Return GenerateUrl(screenshotApiBaseUrl, options)
    End Function

    Private Function GenerateUrl(ByVal baseUrl As String, ByVal options As Dictionary(Of String, String)) As String
        Dim apiUrl As New StringBuilder(baseUrl)
        apiUrl.Append("key=").Append(customerKey)
        If Not String.IsNullOrEmpty(secretPhrase) Then
            apiUrl.Append("&hash=").Append(CalculateHash(options.Item("url") + secretPhrase))
        End If
        For Each pair As KeyValuePair(Of String, String) In options
            Dim key As String = pair.Key
            Dim value As String = pair.Value
            apiUrl.Append("&").Append(key).Append("=").Append(WebUtility.UrlEncode(value))
        Next

        Return apiUrl.ToString()
    End Function

    Private Function CalculateHash(ByVal text As String) As String
        Dim md5 As MD5 = MD5.Create()
        Dim bytes As Byte() = md5.ComputeHash(Encoding.UTF8.GetBytes(text))
        Dim sb As New StringBuilder()
        For n As Integer = 0 To bytes.Length - 1
            sb.Append(bytes(n).ToString("X2"))
        Next n
        Return sb.ToString()
    End Function



End Class
