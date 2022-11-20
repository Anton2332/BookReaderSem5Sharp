﻿namespace DAL2.Models;

public class QueryStringParameters
{
    private const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 5;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
    }
    
    public string OrderBy { get; set; }
    public string Order { get; set; }
}