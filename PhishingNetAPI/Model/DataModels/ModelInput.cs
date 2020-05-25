//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace Model.DataModels
{
    public class ModelInput
    {
        [ColumnName("email"), LoadColumn(0)]
        public string Email { get; set; }


        [ColumnName("Category"), LoadColumn(1)]
        public bool Category { get; set; }


    }
}
