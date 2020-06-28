using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CsvTools
{
    public static List<string> GenerateCsv (List<List<string>> data, List<string> rowHeader, char separator = ',')
    {
        List<string> convertedRowData = new List<string>();
        string convertedHeaders = "";
        foreach (string header in rowHeader)
        {
            convertedHeaders = convertedHeaders + header + separator;
        } 
        convertedRowData.Add(convertedHeaders);
        foreach (List<string> row in data)
        {
            string convertedRow = "";
            foreach (string items in row)
            {
                convertedRow = convertedRow + items + separator;
            }
            convertedRowData.Add(convertedRow);
        }
        
        return convertedRowData;
    }

    public static bool SaveFile(string fileAddress, List<string> toSave, string extensions = ".csv")
    {
        try
        {
            using (StreamWriter csvWriter = new StreamWriter(fileAddress+extensions))
            {
                foreach (string line in toSave)
                {
                    csvWriter.WriteLine(line);
                }
                csvWriter.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
        
        return true;
    }
}
