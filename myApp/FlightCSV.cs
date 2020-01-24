using System;

namespace myApp
{
    public class FlightCSV
    {
        public string ReturnMessage()
        {
            return "Happy coding!";
        }
        public FlightCSV()
        {
            //return new FlightCSV();
        }
        
        public FlightCSV Add(FlightCSV f)
        {
            FlightCSV flightCSV = new FlightCSV();
            flightCSV = f;
            return flightCSV;
        }
        public string aircraft_type;
        public int altitude;
        public string	callsign;
        public DateTime	dateTime;
        public string	destination;
        public string heading; 
        public string	id;
        public string	is_on_ground;
        public string	latitude;
        public string	longitude;
        public string	mode_s_address;
        public string	origin;
        public string	registration;
        public string	source;
        public string	source_data_type;
        public string	source_flight_id;
        public string	source_update_type;
        public string	speed;
        public string	squawk;
        public string	timestamp;
        public string	vertical_speed;
        public static FlightCSV FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            FlightCSV flightCSV = new FlightCSV();
            try{
                flightCSV.aircraft_type = Convert.ToString(values[0]);
                Int32.TryParse(values[1], out flightCSV.altitude);
                flightCSV.callsign = Convert.ToString(values[2]);
                bool t = DateTime.TryParse(values[3].Replace("\"",""),out flightCSV.dateTime);
                //flightCSV.dateTime = Convert.ToString(values[3]);
                flightCSV.destination = Convert.ToString(values[4]);
                flightCSV.heading = Convert.ToString(values[5]); 
                flightCSV.id = Convert.ToString(values[6]);
                flightCSV.is_on_ground = Convert.ToString(values[7]);
                flightCSV.latitude = Convert.ToString(values[8]);
                flightCSV.longitude = Convert.ToString(values[9]);
                flightCSV.mode_s_address = Convert.ToString(values[10]);
                flightCSV.origin = Convert.ToString(values[11]);
                flightCSV.registration = Convert.ToString(values[12]);
                flightCSV.source = Convert.ToString(values[13]);
                flightCSV.source_data_type = Convert.ToString(values[14]);
                flightCSV.source_flight_id = Convert.ToString(values[15]);
                flightCSV.source_update_type = Convert.ToString(values[16]);
                flightCSV.speed = Convert.ToString(values[17]);
                flightCSV.squawk = Convert.ToString(values[18]);
                flightCSV.timestamp = Convert.ToString(values[19]);
                flightCSV.vertical_speed = Convert.ToString(values[20]);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: "+ ex.ToString());
            }
            
                
            return flightCSV;
        }
    }
}