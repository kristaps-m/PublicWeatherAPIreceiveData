﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicWeatherAPIreceiveData.DataBase.Migrations
{
    public partial class Add_CityRealDataFetchingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CityRealDataFetchingTime",
                table: "WeatherDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityRealDataFetchingTime",
                table: "WeatherDatas");
        }
    }
}
