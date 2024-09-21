using System.Data.SqlClient;
using Dapper;

using fantasticfive1.Models;
using Microsoft.Data.Sqlite;

namespace fantasticfive1.Data
{
    public class LookupService
    {
        private readonly IConfiguration _config;
        public LookupService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Food>> FoodLookup()
        {
            List<Food> foodLocs = new List<Food>();

            try
            {
                string dbPath = _config.GetConnectionString("SupportDb").Replace("Data Source=", "");
                if (!System.IO.File.Exists(dbPath))
                {
                    Console.WriteLine($"Database file not found at {dbPath}");
                }
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    var sql = $@"SELECT Id, Name, Address, Lat, Lon, Hours, Phone, Free
                        FROM Food
                ";
                    var _foodLocs = await connection.QueryAsync<Food>(sql);
                    foodLocs = _foodLocs.ToList();
                }

            }
            catch (Exception ex)
            {
                // food lookup failed
            }

            return foodLocs;
        }
        public async Task<List<Shelter>> ShelterLookup()
        {
            List<Shelter> housing = new List<Shelter>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    var sql = $@"SELECT 
                                Id, 
                                Name, 
                                Address, 
                                Lat, 
                                Lon, 
                                PhoneNumber, 
                                Hours, 
                                Womens, 
                                Mens, 
                                ChildFriendly, 
                                PetFriendly, 
                                AllWelcome
                            FROM Shelters
                ";
                    var _housing = await connection.QueryAsync<Shelter>(sql);
                    housing = _housing.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return housing;
        }

        public async Task<List<Shelter>> ShelterLookupWQs(int WomenChildren, int PetFriendly)
        {
            List<Shelter> housing = new List<Shelter>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    var sql = $@"SELECT 
                                Id, 
                                Name, 
                                Address, 
                                Lat, 
                                Lon, 
                                PhoneNumber, 
                                Hours, 
                                Womens, 
                                Mens, 
                                ChildFriendly, 
                                PetFriendly, 
                                AllWelcome
                            FROM Shelters
                        WHERE Womens = '{WomenChildren}'
                        and PetFriendly = {PetFriendly}
                ";
                    var _housing = await connection.QueryAsync<Shelter>(sql);
                    housing = _housing.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return housing;
        }


        public async Task<List<Landmark>> LandmarkLookup()
        {
            List<Landmark> landmarkLocs = new List<Landmark>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    // Query to select all columns from the Landmarks table
                    var sql = @"SELECT Id, Name, Address, Lat, Lon, Type, Hours, PhoneNumber, Wifi, AC
                        FROM Landmarks";

                    // Execute query and map the results to Landmark class
                    var _landmarkLocs = await connection.QueryAsync<Landmark>(sql);
                    landmarkLocs = _landmarkLocs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                Console.WriteLine($"Error: {ex.Message}");
            }

            return landmarkLocs;
        }

        public async Task<List<Landmark>> resourceByType(string type)
        {
            List<Landmark> landmarkLocs = new List<Landmark>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    // Log the type being queried
                    Console.WriteLine($"Querying landmarks of type: {type}");

                    // Parameterized query, using LOWER to handle case-insensitive search
                    var sql = @"SELECT Id, Name, Address, Lat, Lon, Type, Hours, PhoneNumber, Wifi, AC
                        FROM Landmarks
                        WHERE LOWER(Type) = LOWER(@Type)";

                    // Execute query and map the results to Landmark class
                    var _landmarkLocs = await connection.QueryAsync<Landmark>(sql, new { Type = type });
                    landmarkLocs = _landmarkLocs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                Console.WriteLine($"Error: {ex.Message}");
            }

            return landmarkLocs;
        }



        public async Task<List<Job>> JobLookup()
        {
            List<Job> jobLocs = new List<Job>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    // Query to select all columns from the Jobs table
                    var sql = @"SELECT Id, Title, Time, Experience, Description, Expires
                        FROM Jobs";

                    // Execute query and map the results to Job class
                    var _jobLocs = await connection.QueryAsync<Job>(sql);
                    jobLocs = _jobLocs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                Console.WriteLine($"Error: {ex.Message}");
            }

            return jobLocs;
        }

        public async Task<List<DonationPass>> DonationPassLookup()
        {
            List<DonationPass> donationPassLocs = new List<DonationPass>();

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString("SupportDb")))
                {
                    // Query to select all columns from the DonationPasses table
                    var sql = @"SELECT Id, DonorName, DonorEmail, PassType, PassCode, Value
                        FROM DonationPasses";

                    // Execute query and map the results to DonationPass class
                    var _donationPassLocs = await connection.QueryAsync<DonationPass>(sql);
                    donationPassLocs = _donationPassLocs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                Console.WriteLine($"Error: {ex.Message}");
            }

            return donationPassLocs;
        }

    }
}
