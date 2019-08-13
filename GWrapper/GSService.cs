using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GW {
    public class GSService {
        private string[] m_Scopes = { SheetsService.Scope.Spreadsheets };
        private string m_AppName = "Google Sheets Wrapper";

        private SheetsService m_Service;
        private UserCredential m_UserCredential;

        public GSService() {
            /* Authorize the user - this could possibly go into another class. */
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read)) {
                /* The file token.json stores the user's access and refresh tokens, and is created
                 automatically when the authorization flow completes for the first time. */
                string credPath = "token.json";
                m_UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    m_Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            /* Create Google Sheets API service. */
            m_Service = new SheetsService(new BaseClientService.Initializer() {
                HttpClientInitializer = m_UserCredential,
                ApplicationName = m_AppName,
            });
        }

		public SheetsService SheetsService {
			get { return m_Service; }
		}
    }
}
