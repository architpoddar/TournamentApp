// See https://aka.ms/new-console-template for more information


using ExcelDataReader;
using System.Data;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using UpdateData;

Console.WriteLine("Hello, World!");
await ImportPlayers();


async Task ImportPlayers()
{
    Console.WriteLine("TEST");

    try
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        List<Player> players = new List<Player>();  

        IExcelDataReader excelReader;
        DataTable dtPlayers = new DataTable();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using (var stream = File.Open(@"D:\Projects\TournamentApp\UpdateData\Yuva Premier League Registration.xlsx", FileMode.Open, FileAccess.Read))
        {
            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet ds = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            if (ds.Tables.Count > 0)
            {
                dtPlayers = ds.Tables[0];
            }

            foreach (DataRow item in dtPlayers.Rows)
            {
                var email = Convert.ToString(item["Email Address"]);
                var fullName = Convert.ToString(item["Full Name"]);
                var bldg = Convert.ToString(item["Bldg/Society"]);
                var flatNo = Convert.ToString(item["Wing/Flat No."]);
                var mobNo = Convert.ToString(item["Mobile Number"]);
                var age = Convert.ToInt32(item["Age"]);
                var gender = Convert.ToString(item["Gender"]);
                var shirtSize = Convert.ToString(item["T-Shirt Size"]);
                var shirtNo = Convert.ToString(item["Number on T-Shirt"]);
                var shirtName = Convert.ToString(item["Name on T-Shirt"]);
                var pictureUrl = Convert.ToString(item["Picture"]);
                var expertise = Convert.ToString(item["Briefly explain your expertise in the sports you are participating in"]);

                var player = new Player()
                {
                    Email = email,
                    FullName = fullName,
                    Building = bldg,
                    FlatNo = flatNo,
                    MobileNo = mobNo,
                    Age = age,
                    Gender = gender,
                    ShirtSize = shirtSize,
                    ShirtName = shirtName,
                    ShirtNumber = shirtNo,
                    PictureUrl = pictureUrl,
                    Expertise = expertise
                };

                var sports = new List<string>();

                var cricketMale = Convert.ToString(item["Cricket - Male"]);
                var volleyball = Convert.ToString(item["Volleyball"]);
                var football = Convert.ToString(item["Football"]);
                var cricketFemale = Convert.ToString(item["Cricket - Female"]);
                var badminton = Convert.ToString(item["Badminton - Mixed Category"]);

                // Male Cricket
                if(!string.IsNullOrEmpty(cricketMale))
                {
                    if (cricketMale.Contains("Box Cricket"))
                    {
                        sports.Add("boxCricket");
                        player.IsBoxCricket = true;
                    }

                    if (cricketMale.Contains("Men's Cricket"))
                    {
                        sports.Add("mensCricket");
                        player.IsMensCricket = true;
                    }

                    if (cricketMale.Contains("Teen Cricket"))
                    {
                        sports.Add("teensCricket");
                        player.IsTeensCricket = true;
                    }

                    if (cricketMale.Contains("U-12 Cricket"))
                    {
                        sports.Add("u12boysCricket");
                        player.IsU12BoysCricket = true;
                    }
                }
                
                // Female Cricket
                if (!string.IsNullOrEmpty(cricketFemale))
                {
                    if (cricketFemale.Contains("Ladies Cricket"))
                    {
                        sports.Add("ladiesCricket");
                        player.IsLadiesCricket = true;
                    }

                    if (cricketFemale.Contains("U-13 Cricket"))
                    {
                        sports.Add("u13girlsCricket");
                        player.IsU13GirlsCricket = true;
                    }
                }
                
                // Other Sports
                if (!string.IsNullOrEmpty(volleyball))
                {
                    sports.Add("volleyball");
                    player.IsVolleyball = true;
                }

                if (!string.IsNullOrEmpty(football))
                {
                    sports.Add("football");
                    player.IsFootball = true;
                }

                if (!string.IsNullOrEmpty(badminton))
                {
                    sports.Add("badminton");
                    player.IsBadminton = true;
                }

                player.Sports = sports;

                var sportsCount = sports.Count;

               if(sportsCount > 0)
                {
                    player.ExpectedPayment = 1000 + (sportsCount - 1) * 300;
                }

                players.Add(player);
            }

            foreach(var player in players)
            {
                await firebaseHelper.AddPlayer(player);
            }
        }
    }
    catch(Exception ex)
    {

    }
}