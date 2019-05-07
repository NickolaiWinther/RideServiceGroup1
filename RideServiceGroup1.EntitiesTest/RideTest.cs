using RideServiceGroup1.DAL;
using RideServiceGroup1.Entities;
using System;
using Xunit;

namespace RideServiceGroup1.EntitiesTest
{
    public class RideTest
    {
        private Ride CreateRide()
        {
            return new Ride()
            {
                Id = 1
            };
        }
        private Ride CreateRideWithMultipleReports()
        {
            Ride ride = CreateRide();
            ride.Reports.Add(CreateReport(Status.Broken));
            ride.Reports.Add(CreateReport(Status.Working));
            return ride;
        }

        private Report CreateReport(Status status)
        {
            return CreateReport(status, DateTime.Now);
        }


        private Report CreateReport(Status status, DateTime reportTime)
        {
            return new Report()
            {
                Status = status,
                ReportTime = reportTime
            };
        }

        private Report CreateBrokenReport()
        {
            return new Report()
            {
                Status = Status.Broken

            };
        }

        private Report CreateBeingRepairedReport()
        {
            return new Report()
            {
                Status = Status.BeingRepaired
            };
        }
        [Fact]
        public void NumberOfShutDowns_ShouldReturnFour()
        {
            Ride ride = CreateRide();
            
            ride.Reports.Add(CreateReport(Status.BeingRepaired, DateTime.Now.AddDays(-7)));
            ride.Reports.Add(CreateReport(Status.Broken, DateTime.Now.AddDays(-6)));
            ride.Reports.Add(CreateReport(Status.Broken, DateTime.Now.AddDays(-4)));
            ride.Reports.Add(CreateReport(Status.Broken, DateTime.Now.AddDays(-2)));
            ride.Reports.Add(CreateReport(Status.Broken, DateTime.Now.AddDays(-1)));

            Assert.Equal(4, ride.NumbersOfShutdowns());
        }

        [Fact]
        public void NumberOfShutDowns_ShouldReturnZeroWithNoReports()
        {
            Ride ride = CreateRide();
            
            Assert.Equal(0, ride.NumbersOfShutdowns());
        }

        [Fact]
        public void NumberOfShutDowns_ShouldReturnZeroWithNoBrokenReports()
        {
            Ride ride = CreateRide();
            
            ride.Reports.Add(CreateBeingRepairedReport());
            
            Assert.Equal(0, ride.NumbersOfShutdowns());
        }

        [Fact]
        public void NumberOfShutDowns_ShouldReturnOne()
        {
            Ride ride = CreateRideWithMultipleReports();

            Assert.Equal(1, ride.NumbersOfShutdowns());
        }

        [Fact]
        public void DaysSinceLastShutdown_ShouldReturnNeg1WithNoReports()
        {
            Ride ride = CreateRide();

            Assert.Equal(-1, ride.DaysSinceLastShutdown());
        }

        [Fact]
        public void DaysSinceLastShutdown_ShouldReturnNeg1WithNoBrokenReports()
        {
            Ride ride = CreateRide();

            ride.Reports.Add(CreateBeingRepairedReport());

            Assert.Equal(-1, ride.DaysSinceLastShutdown());
        }

        [Fact]
        public void DaysSinceLastShutdown_ShouldReturn0WithBrokenReportFromToday()
        {
            Ride ride = CreateRide();

            ride.Reports.Add(CreateReport(Status.Broken, DateTime.Now));

            Assert.Equal(0, ride.DaysSinceLastShutdown());
        }


        [Fact]
        public void DaysSinceLastShutdown_ShouldReturnTen()
        {
            Ride ride = CreateRide();
            Report report1 = new Report()
            {
                Status = Status.Broken,
                ReportTime = DateTime.Now.AddDays(-10)
            };

            Report report2 = new Report()
            {
                Status = Status.Broken,
                ReportTime = DateTime.Now.AddDays(-14)
            };

            Report report3 = new Report()
            {
                Status = Status.BeingRepaired,
                ReportTime = DateTime.Now.AddDays(-7)
            };

            ride.Reports.Add(report1);
            ride.Reports.Add(report2);
            ride.Reports.Add(report3);

            Assert.Equal(10, ride.DaysSinceLastShutdown());
        }
    }
}
