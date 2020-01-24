using System;
using System.IO;
using System.Collections.Generic;


namespace myApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Jagdish!");
            Console.WriteLine("The current time is " + DateTime.Now);
            var c1 = new FlightCSV();
            Console.WriteLine($"Hello Jagdish {c1.ReturnMessage()}");

            string path = Path.GetFileName(Directory.GetCurrentDirectory() + "/N685DA__2017-04-16_18.csv");

            Console.WriteLine(path);
            //FlightCSV[] flightCSV = null;
            var fi1 = new FileInfo(path);
            HashSet<FlightCSV> taken = new HashSet<FlightCSV>();
            HashSet<FlightCSV> pinkfroot = new HashSet<FlightCSV>();
            HashSet<FlightCSV> adsbexchange = new HashSet<FlightCSV>();

            // Open the file to read from.
            using (StreamReader sr = fi1.OpenText()) 
            {
                Console.WriteLine(fi1.Length);
                var s = ""; int i=0; int numFlights = 0;
                while ((s = sr.ReadLine()) != null) 
                {
                    //Console.WriteLine(s);
                    FlightCSV fCSV = FlightCSV.FromCsv(s);
                    if (i==0)
                    {
                        i++;
                    }
                    else
                    {
                        taken.Add(fCSV);   
                        if(fCSV.source.Replace("\"","").Trim().ToLower() == "adsbexchange")
                        {
                            adsbexchange.Add(fCSV);
                            
                        }
                        else
                        {
                            pinkfroot.Add(fCSV);
                        }
                    }                 //Console.WriteLine(fCSV.squawk);
                   // flightCSV[i++] = new FlightCSV(); //fCSV;
                }
                Console.WriteLine(taken.Count.ToString());
                HashSet<Int32> squawk = new HashSet<Int32>();
                //HashSet<FlightCSV> flights = new HashSet<FlightCSV>();
                HashSet<String> flights1 = new HashSet<String>();
                HashSet<String> origin = new HashSet<String>();
                HashSet<String> callsign = new HashSet<String>();
                HashSet<String> dateString = new HashSet<String>();
                i=0;
                foreach(FlightCSV f in taken)
                {
                    // if(f.source_data_type.Trim() == "2")
                    // {
                    //     adsbexchange.Add(f);
                        
                    // }
                    // else
                    // {
                    //     pinkfroot.Add(f);
                    // }
                    if(f.origin.ToUpper().Trim() != f.destination.ToUpper().Trim())
                        origin.Add("Origin is "+ f.origin + " and Destination is "+ f.destination);
                    // try{
                    // dateString.Add(f.dateTime.Replace("\"","").Substring(0,13));
                    // }catch{ 
                    //         Console.WriteLine(f.dateTime);
                    //     }

                    //if (f.origin != "" && f.destination !="" && f.origin != f.destination)
                    if (f.origin != "" && f.destination !="")
                    {
                        numFlights++;
                        
                    }
                    try{
                        string a = f.squawk.Replace("\"","");
                        string c = f.callsign.Replace("\"","");
                        if(a!=""){
                            squawk.Add(Convert.ToInt32(a));
                            //squawk1.Add(Convert.ToInt32(a));
                            //if(squawk)
                            // if(!flights1.Contains(a))
                            // {
                                if(f.origin.Trim() == "")
                                {
                                    flights1.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination + " source: " + f.source);

                                }
                                if(f.origin.ToUpper().Trim() != f.destination.ToUpper().Trim())
                                    flights1.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination + " source: " + f.source);
                                //Console.WriteLine("Origin: " + f.origin + " Destination:" + f.destination + " source: " + f.source);
                            //}
                        }
                        if(c!="")
                        {
                            callsign.Add(c);
                        }
                    }
                    catch{ 
                            Console.WriteLine(f.squawk);
                        }

                }
                Console.WriteLine("Number of flights based on origin and destination being different= "+numFlights);
                Console.WriteLine("Number of flights based on unique Squawks = "+squawk.Count);
                Console.WriteLine("Number of flights based on unique callSign = "+callsign.Count);
                //Console.WriteLine("Number of flights based on unique dateTime = "+dateString.Count);
                Console.WriteLine("Origin and Destination list");
                
                foreach(String od in origin)
                {
                    Console.WriteLine(od.ToString());
                }
                foreach(String od1 in flights1)
                {
                    Console.WriteLine(od1.ToString());
                }
                Console.WriteLine(" list count" + flights1.Count);
                Console.WriteLine(" pinkfroot count" + pinkfroot.Count);
                Console.WriteLine(" adsbexchange count" + adsbexchange.Count);

                HashSet<String> flights2 = new HashSet<String>();
                HashSet<String> Squawks2 = new HashSet<String>();
                HashSet<String> uniqueFlightswithOrigin = new HashSet<String>();
                foreach(FlightCSV f in pinkfroot)
                {
                    
                    string a = f.squawk.Replace("\"","");
                    
                    if(f.origin.Trim() == "" ) 
                    {
                        Squawks2.Add(f.squawk);
                        flights2.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination );

                    }
                    if(f.origin.ToUpper().Trim() != f.destination.ToUpper().Trim()) 
                    {
                        Squawks2.Add(f.squawk);
                       uniqueFlightswithOrigin.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination + " source:" + f.source);
                        flights2.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination + " source:" + f.source);
                    }
                }
                foreach(FlightCSV f in adsbexchange)
                {
                    
                    string a = f.squawk.Replace("\"","");
                    if( a.Trim() == "")
                       {}
                    else
                    {
                        Squawks2.Add(f.squawk);
                        if(f.origin.Trim() == "" ) 
                        {
                            
                            flights2.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination );

                        }
                        if(f.origin.ToUpper().Trim() != f.destination.ToUpper().Trim()) 
                        {
                            
                            flights2.Add("For Squawk: " + a + " flight Origin: " + f.origin + " Destination:" + f.destination + " source:" + f.source);
                        }
                    }
                }
                foreach(string s2 in flights2)
                    Console.WriteLine(s2);
                Console.WriteLine(" unique total count" + flights2.Count);
                Console.WriteLine("Total flights: " + Squawks2.Count);
                //Console.WriteLine("Total flights with origin and destination in data: " + Squawks2.Count);
                Console.WriteLine("Total flights with valid origin and destination in data: " + uniqueFlightswithOrigin.Count);
                foreach(string s2 in uniqueFlightswithOrigin)
                    Console.WriteLine(s2);

                //FlightCSV[] flightCSV = new FlightCSV[taken.Count];
               // foreach(string s in ta)
                //foreach(FlightCSV f in flightCSV)
                //{
                   // Console.WriteLine(f.squawk);
                //}
                //int i=0; 
                int j=0;
                HashSet<String> uniqueFlights = new HashSet<String>();
                List<FlightCSV> listFlights = new List<FlightCSV>(taken);
                listFlights.Sort((x, y) => x.dateTime.CompareTo(y.dateTime));
                try{
                    foreach(FlightCSV f in taken)
                    {
                        if(j<taken.Count-1)
                        {
                            TimeSpan diff = listFlights[j+1].dateTime - listFlights[j].dateTime; 
                            j++;
                            if (diff.Minutes < 0)
                            {
                                diff = diff + TimeSpan.FromDays(1);
                            }
                            if(diff.Minutes > 2 && f.altitude < 1000 )
                            {  Console.WriteLine("altitude: "+ f.altitude);
                                uniqueFlights.Add("Altitude:" + f.altitude + " Squawk:" + f.squawk + " origin:"+ f.origin + " Destination: "+ f.destination);
                            //if(f) Console.WriteLine()
                            }  
                        }                  
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            foreach(string s2 in uniqueFlights)
                    Console.WriteLine(s2);
            Console.WriteLine("Based on time, unique flights:" + uniqueFlights.Count);

            }

        }
    }
}
