# screenshotmachine-vb

This demo shows how to call online screenshot machine API using Visual Basic programming language.

## Installation
First, you need to create a free/premium account at [www.screenshotmachine.com](https://www.screenshotmachine.com) website. After registration, you will see your customer key in your user profile. Also secret phrase is maintained here. Please, use secret phrase always, when your API calls are called from publicly available websites.  

Set-up your customer key and secret phrase (if needed) in the script:

```vbnet
    Dim customerKey As String = "PUT_YOUR_CUSTOMER_KEY_HERE"
    Dim secretPhrase As String = "" REM leave secret phrase empty, If Not needed
```

Set other options to fulfill your needs: 

```vbnet
    Dim options As New Dictionary(Of String, String)
    REM mandatory parameter
    options.Add("url", "https://www.google.com")
    REM  all next parameters are optional, see our API guide for more details
    options.Add("dimension", "1366x768") REM Or "1366xfull" For full length screenshot
    options.Add("device", "desktop")
    options.Add("format", "png")
    options.Add("cacheLimit", "0")
    options.Add("delay", "200")
    options.Add("zoom", "100")
```
More info about options can be found in our [API doc](https://www.screenshotmachine.com/api.php).  

 Sample code
-----

```vbnet
Imports System.Net

Public Class Client

    Public Shared Sub Main(args() As String)
        Dim customerKey As String = "PUT_YOUR_CUSTOMER_KEY_HERE"
        Dim secretPhrase As String = "" REM leave secret phrase empty, If Not needed

        Dim options As New Dictionary(Of String, String)
        REM mandatory parameter
        options.Add("url", "https://www.google.com")
        REM  all next parameters are optional, see our API guide for more details
        options.Add("dimension", "1366x768") REM Or "1366xfull" For full length screenshot
        options.Add("device", "desktop")
        options.Add("format", "png")
        options.Add("cacheLimit", "0")
        options.Add("delay", "200")
        options.Add("zoom", "100")

        Dim sm As ScreenshotMachine = New ScreenshotMachine(customerKey, secretPhrase)
        Dim apiUrl As String = sm.GenerateApiUrl(options)

        REM use final apiUrl where needed
        Console.WriteLine(apiUrl)
        
    End Sub

End Class
```
Generated ```apiUrl```  link can be placed in ```<img>``` tag or used in your business logic later.

If you need to store captured screenshot as an image, just call:

```vbnet
    Dim apiUrl As String = sm.GenerateApiUrl(options)

    REM or save screenshot directly
    Dim client As New WebClient()
    Dim output As String = "output.png"
    client.DownloadFile(apiUrl, output)
    Console.WriteLine("Screenshot saved as " + output)

```

Captured screenshot will be saved as ```output.png``` file in current directory.

# License

The MIT License (MIT)    