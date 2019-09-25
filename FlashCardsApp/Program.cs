﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

// from https://developers.google.com/sheets/api/quickstart/dotnet#step_2_prepare_the_project
/* using oauth 2 credential json called client_secret.json which needs to be verified by google still.
 * google api keys managed at: https://console.developers.google.com/apis/credentials?project=quickstart-1568410709869&authuser=0
 * */
namespace SheetsQuickstart
{
  class Program
  {
    // If modifying these scopes, delete your previously saved credentials
    // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    static string ApplicationName = "Google Sheets API .NET Quickstart";

    static void Main(string[] args)
    {
      UserCredential credential;

      using (var stream =
          new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
      {
        // The file token.json stores the user's access and refresh tokens, and is created
        // automatically when the authorization flow completes for the first time.
        string credPath = "token.json";
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
        Console.WriteLine("Credential file saved to: " + credPath);
      }

      // Create Google Sheets API service.
      var service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = ApplicationName,
      });

      // Define request parameters.
      String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
      String range = "Class Data!A2:E";
      SpreadsheetsResource.ValuesResource.GetRequest request =
              service.Spreadsheets.Values.Get(spreadsheetId, range);

      // Prints the names and majors of students in a sample spreadsheet:
      // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
      ValueRange response = request.Execute();
      IList<IList<Object>> values = response.Values;
      if (values != null && values.Count > 0)
      {
        Console.WriteLine("Name, Major");
        foreach (var row in values)
        {
          // Print columns A and E, which correspond to indices 0 and 4.
          Console.WriteLine("{0}, {1}", row[0], row[4]);
        }
      }
      else
      {
        Console.WriteLine("No data found.");
      }
      Console.Read();
    }
  }
}