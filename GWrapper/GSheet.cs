using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

/* TODO:
    - Allow user to set the spreadsheet to editable by changing the scopes array. */

namespace GW {
    /* This class allows the user to create and interact with a Google Spreadsheet. */
    public class GSheet {
        private GSService m_SheetsService;
		private Spreadsheet m_SpreadSheet;

        /* Constructor.
         Params:
			- service : GSService object to interact with the Google Sheets service.  
            - ssTitle : title of spreadsheet. 
			- fsTitle : title of the first sheet. */
        public GSheet(GSService service, string ssTitle, string fsTitle) {
            m_SheetsService = service;

			/* Create default sheet. */
			Sheet firstSheet = new Sheet();
			firstSheet.Properties = new SheetProperties();
			firstSheet.Properties.Title = fsTitle;

			/* Create spreadsheet. */
			Spreadsheet sheetBody = new Spreadsheet();
			sheetBody.Properties = new SpreadsheetProperties();
			sheetBody.Properties.Title = ssTitle;
			sheetBody.Sheets = new List<Sheet>() { firstSheet }; 

			m_SpreadSheet = m_SheetsService.SheetsService.Spreadsheets.Create(sheetBody).Execute();
        }
    }
}
                     