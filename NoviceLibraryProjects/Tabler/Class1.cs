using System;

namespace Tabler
{
    public class Tab
    {
        /*
        
        Get width of each col
        - take a string
        - break into lines
        - get num of columns per line
        - init colLenghts of each value string
        - read each line
        - read each value separated by commas
        - get length of each value
        - update colLength each time read val is greater than previously read val
        
        Iterate through lines and add spaces to each colVal so that all colVals are same width
        */
        public string Tabify (string s)
        {
            return s.Replace(' ', '\t');
        }
    }
}
