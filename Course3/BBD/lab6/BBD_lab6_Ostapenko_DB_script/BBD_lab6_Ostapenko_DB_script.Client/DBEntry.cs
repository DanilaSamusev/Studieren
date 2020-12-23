namespace BBD_lab6_Ostapenko_DB_script.Client
{
    class DBEntry
    {
        public string TableName { get; set; }
        
        public string Columns { get; set; }
        
        public string Values { get; set; }

        public DBEntry(string tableName, string columns, string values)
        {
            TableName = tableName;
            Columns = "(" + columns + ")";
            Values = "(" + values + ")";
        }
    }
}
