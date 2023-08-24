using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Trakk.Utils.Extensions.EnumExtensions;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;
using Trakk.WebApi.DatabaseModels.Models.Partials;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;
using Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;

using Trakk.WebApi.Models;
using Position = Trakk.WebApi.DatabaseModels.Models.Position;

namespace Trakk.WebApi.DatabaseModels.Seeding;



public static class SeedingExtensions
{
    public static void ApplySeedData(this ModelBuilder builder)
    {
        builder.SeedEnum<Enums.CommunicationEventType, CommunicationEventType>(x => new CommunicationEventType { CommunicationEventTypeId = (int)x, Name = x.ToString() });
        builder.SeedEnum<Enums.GeofenceType, GeofenceType>(x => new GeofenceType { GeofenceTypeId = (int)x, Name = x.ToString() });
        builder.SeedEnum<Enums.Language, Language>(x => new Language { LanguageId = (int)x, Name = x.ToString() });
        builder.SeedEnum<Enums.AccountRight, RightType>(x => new RightType { RightTypeId = x, Name = x.ToString() });
        builder.SeedEnum<Enums.JobType, JobType>(x => new JobType { JobTypeId = (int)x, Name = x.ToString() });
        builder.SeedEnum<Enums.JobIntervalType, JobIntervalType>(x => new JobIntervalType { Name = x.ToString(), JobIntervalTypeId = (int)x });
        builder.SeedEnum<Enums.Services, Service>(x => new Service { Name = x.ToString(), ServiceId = (int)x });
        builder.SeedEnum<Enums.HardwareType, HardwareType>(type => new HardwareType() { HardwareTypeId = (int)type, Name = type.ToString(), HasSimCardSlot = type.GotSimSlot() });
        builder.SeedEnum<Enums.AccountEventType, AccountEventType>(x => new AccountEventType { Name = x.ToString(), AccountEventTypeId = (int)x });
        builder.SeedEnum<Enums.AccountRole, AccountRole>(x => new AccountRole { Name = x.ToString(), AccountRoleId = (int)x });
        //builder.SeedEnum<Enums.VehicleEventType, VehicleEventType>(x => new VehicleEventType{Name = x.ToString().NormalizeName(), VehicleEventTypeId = (int)x});
        builder.SeedEnum<Enums.DriverEventType, DriverEventType>(x => new DriverEventType { Name = x.ToString(), DriverEventTypeId = (int)x });
        builder.SeedEnum<Enums.RootAccountType, RootAccountType>(x => new RootAccountType { Name = x.ToString(), RootAccountTypeId = (int)x });
        builder.SeedEnum<Enums.SmsOperator, SmsOperator>(x => x.ToString().ToSmsOperator());
        builder.SeedEnum<Enums.HardwareStatus, HardwareStatus>(x => new HardwareStatus { Name = x.ToString(), HardwareStatusId = (int)x });
        builder.SeedEnum<Enums.VehicleReminderType, VehicleReminderType>(x => new VehicleReminderType { Name = x.ToString(), VehicleReminderTypeId = (int)x });
        builder.SeedEnum<Enums.CustomerFeature, CustomerFeature>(x => new CustomerFeature{Name = x.ToString(), Id = x});
        builder.SeedIcons();
        builder.Entity<CategoryType>().HasData(DefaultCategories());
    }


    public static void PopulateDb(this ModelBuilder builder)
    {
        Console.WriteLine("Populating DB is running...");
        builder.CustomerAdminSeed();
        builder.RootAccountSeed();
        builder.CustomerSeed();
        builder.ContactSeed();
        builder.AccountsSeed();
        builder.GroupsSeed();
        builder.AccountGroupMapSeed();
        builder.PositionsSeed();
        builder.HardwareSeed();
        builder.ScheduleSeed();
        builder.GeofenceSeed();
        builder.ScheduleEntriesSeed();
        builder.TrakkersSeed();
        builder.AssetsSeed();
        builder.AssetsEventsSeed();
        builder.TrakkersEventsSeed();
        builder.VehiclesSeed();
        builder.VehiclesEventsSeed();
        builder.CongestionTaxDataSeed();
        builder.PassagesSeed();
        builder.EventsPositionsSeed();
        builder.GeofenceEventsSeed();
        builder.ActiveAlertsSeed();

    }

    public static void GeofenceEventsSeed(this ModelBuilder builder)
    {
        builder.Entity<GeofenceEvent>().HasData(
        new GeofenceEvent
        {
            GeofenceEventId = 1,
            GeofenceId = 1,
            GeofenceName = "GeoFence#1",
            TrakkerId = 1,
            EnteredOn = new DateTime(2023, 1, 1, 0, 0, 0, 0),
            LeftOn = new DateTime(2023, 1, 1, 1, 1, 0, 0, 0),

        },
        new GeofenceEvent
        {
          GeofenceEventId = 2,
          GeofenceId = 2,
          GeofenceName = "GeoFence#2",
          TrakkerId = 1,
          EnteredOn = new DateTime(2023, 1, 1, 0, 0, 0, 0),
          LeftOn = new DateTime(2023, 1, 1, 1, 1, 0, 0, 0),

        },
        new GeofenceEvent
        {
            GeofenceEventId = 3,
            GeofenceId = 3,
            GeofenceName = "GeoFence#3",
            TrakkerId = 1,
            EnteredOn = new DateTime(2023, 1, 1, 0, 0, 0, 0),
            LeftOn = new DateTime(2023, 1, 1, 1, 0, 0, 0),

        },
      new GeofenceEvent
      {
          GeofenceEventId = 4,
          GeofenceId = 4,
          GeofenceName = "GeoFence#4",
          TrakkerId = 1,
          EnteredOn = new DateTime(2023, 1, 1, 0, 0, 0, 0),
          LeftOn = new DateTime(2023, 1, 1, 1, 0, 0, 0),

      }
      ,
      new GeofenceEvent
      {
          GeofenceEventId = 5,
          GeofenceId = 5,
          GeofenceName = "GeoFence#5",
          TrakkerId = 1,
          EnteredOn = new DateTime(2023, 1, 1, 0, 0, 0, 0),
          LeftOn = new DateTime(2023, 1, 1, 1, 0, 0, 0),

      }
        ); 
    }
        public static void ActiveAlertsSeed(this ModelBuilder builder)
    {
        builder.Entity<ActiveAlert>().HasData(
            new ActiveAlert
            {
                ActiveAlertId = 1,
                GeofenceEventId= 1,
                TrakkerEventId= 1,

            },
            new ActiveAlert
            {
                ActiveAlertId = 2,
                GeofenceEventId= 2,
                TrakkerEventId= 2,

            },
            new ActiveAlert
            {
                ActiveAlertId = 3,
                GeofenceEventId = 3,
                TrakkerEventId = 3,

            },
            new ActiveAlert
            {
                ActiveAlertId =4,
                GeofenceEventId = 4,
                TrakkerEventId = 4,

            },
            new ActiveAlert
            {
                ActiveAlertId = 5,
                GeofenceEventId = 5,
                TrakkerEventId = 5,

            }
            //,
            //new ActiveAlert
            //{
            //    ActiveAlertId = 1,
            //    GeofenceEventId = 1,
            //    TrakkerEventId = 6,
            //}
            );
    }
    public static void EventsPositionsSeed(this ModelBuilder builder)
    {
        builder.Entity<EventPosition>().HasData(
            //new EventPosition
            //{
            //    Id = 1,
            //    VehicleEventId = 2,
            //    PositionId = 1,
            //    TimeStamp = new DateTime(2023, 1, 1, 0, 0, 0, 0),
            //},
            new EventPosition
            {
                Id = 2,
                VehicleEventId = 2,
                PositionId = 2,
                TimeStamp = new DateTime(2023, 1, 1, 0, 5, 5, 0),
            },
            new EventPosition
            {
                Id = 3,
                VehicleEventId = 2,
                PositionId = 3,
                TimeStamp = new DateTime(2023, 1, 1, 0, 10, 10, 0),
            },
            new EventPosition
            {
                Id = 4,
                VehicleEventId = 2,
                PositionId = 4,
                TimeStamp = new DateTime(2023, 1, 1, 0, 20, 15, 0),

            },
            new EventPosition
            {
                Id = 5,
                VehicleEventId = 2,
                PositionId = 5,
                TimeStamp = new DateTime(2023, 1, 1, 0, 30, 20, 0),

            },
            new EventPosition
            {
                Id = 6,
                VehicleEventId = 2,
                PositionId = 6,
                TimeStamp = new DateTime(2023, 1, 1, 0, 40, 25, 0),

            },
            new EventPosition
            {
                Id = 7,
                VehicleEventId = 2,
                PositionId = 7,
                TimeStamp = new DateTime(2023, 1, 1, 0, 50, 30, 0),

            },
            new EventPosition
            {
                Id = 8,
                VehicleEventId = 2,
                PositionId = 8,
                TimeStamp = new DateTime(2023, 1, 1, 1, 0, 35, 0),

            },
            new EventPosition
            {
                Id = 9,
                VehicleEventId = 2,
                PositionId = 9,
                TimeStamp = new DateTime(2023, 1, 1, 1, 0, 40, 0),

            }
            //,
            //new EventPosition
            //{
            //    Id = 10,
            //    VehicleEventId = 2,
            //    PositionId = 10,
            //    TimeStamp = new DateTime(2023, 1, 1, 0, 0, 45, 0),

            //}

            );
    }

        public static void GeofenceSeed(this ModelBuilder builder)
    {
        GeometryFactory geometryFactory = new GeometryFactory();

        // GeoFence #1
        Coordinate imageOutlineCoordinates =
        new Coordinate(11.840515136718752, 58.05699335665829);

        Point point1 = geometryFactory.CreatePoint(imageOutlineCoordinates);

        // GeoFence #2
        imageOutlineCoordinates =
        new Coordinate(11.935840845108034, 57.65406947526958);

        Point point2 = geometryFactory.CreatePoint(imageOutlineCoordinates);

        //  GeoFence #3
        imageOutlineCoordinates =
        new Coordinate(11.91042423248291, 57.650039598314294);

        Point point3 = geometryFactory.CreatePoint(imageOutlineCoordinates);

        //  GeoFence #4
           
        Coordinate[] polyOutlineCoordinates = new Coordinate[]{
            new Coordinate(12.059555, 57.333934),
            new Coordinate(12.131481, 57.339678),
            new Coordinate(12.152252, 57.355423), 
            new Coordinate(12.135944, 57.373476),
            new Coordinate(12.087021,  57.371995),
            new Coordinate(12.073288, 57.359868),
            new Coordinate(12.059555, 57.333934),
        };

        Polygon poly4 = geometryFactory.CreatePolygon(polyOutlineCoordinates);

        //  GeoFence #5

       polyOutlineCoordinates = new Coordinate[]{
            new Coordinate(12.009698, 57.656561),
            new Coordinate(12.011726, 57.652026),
            new Coordinate(12.019075, 57.652875),
            new Coordinate(12.017841, 57.655137),
            new Coordinate(12.017294,  57.657645),
            new Coordinate(12.009698, 57.656561),
        };

        Polygon poly5 = geometryFactory.CreatePolygon(polyOutlineCoordinates);


        builder.Entity<Geofence>().HasData(
       new Geofence
       {
           GeofenceId = 1,
           CustomerId = 1,
           Name = "Stenungsund",
           GeofenceTypeId = 4,
           Geography = point1,
           IsActive = true,
           BufferRadius = 4848,
           ScheduleId = 3252,
       },
       new Geofence
       {
           GeofenceId = 2,
           CustomerId = 1,
           Name = "TRAKK H",
           GeofenceTypeId = 2,
           Geography = point2,
           IsActive = true,
           BufferRadius = 4848,
           ScheduleId = 3252,
       },
       new Geofence
       {
           GeofenceId = 3,
           CustomerId = 1,
           Name = "Fr�lunda torg",
           GeofenceTypeId = 3,
           Geography = point3,
           IsActive = true,
           BufferRadius = 252,
           ScheduleId = 3252,
       },
       new Geofence
       {
           GeofenceId = 4,
           CustomerId = 1,
           Name = "�sa",
           GeofenceTypeId = 2,
           Geography = poly4,
           IsActive = true,
           ScheduleId = 3252,

       },
       new Geofence
       {
           GeofenceId = 5,
           CustomerId = 1,
           Name = "M�lndals bro",
           GeofenceTypeId = 1,
           Geography = poly5,
           IsActive = true,
           ScheduleId = 3252,
       }

       );

    }
    public static void ScheduleSeed(this ModelBuilder builder)
    {
        builder.Entity<Schedule>().HasData(
       new Schedule
       {
           Id = 3252,
           OverrideTime = null,
           TimeZoneInfo = TimeZoneInfo.Local,

       });
     }

    public static void CongestionTaxDataSeed(this ModelBuilder builder)
    {
        builder.Entity<CongestionTaxData>().HasData(
       new CongestionTaxData
       {
           Id = 1
        },
       new CongestionTaxData
       {
           Id = 2
       },
       new CongestionTaxData
       {
           Id = 3
       },
       new CongestionTaxData
       {
           Id = 4
       },
       new CongestionTaxData
       {
           Id = 5
       },
       new CongestionTaxData
       {
           Id = 6
       }
       );
    }
    public static void PassagesSeed(this ModelBuilder builder)
    {
       builder.Entity<Passage>().HasData(
      new Passage
       {
          Id= 1,
          VehicleEventId= 1,
          Area = (CongestionTaxProcessor.Enums.Area) 2,
          TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)4,
          PassageTime = DateTime.Now,
          Cost = 154

      },
       new Passage
       {
           Id = 2,
           VehicleEventId = 2,
           Area = (CongestionTaxProcessor.Enums.Area)1,
           TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)2,
           PassageTime = DateTime.Now,
           Cost = 254

       },
       new Passage
       {
           Id = 3,
           VehicleEventId = 3,
           Area = (CongestionTaxProcessor.Enums.Area)1,
           TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)4,
           PassageTime = DateTime.Now,
           Cost = 555

       },
      new Passage
       {
           Id = 4,
           VehicleEventId = 4,
           Area = (CongestionTaxProcessor.Enums.Area)2,
           TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)2,
           PassageTime = DateTime.Now,
           Cost = 123

       },
      new Passage
      {
          Id = 5,
          VehicleEventId = 5,
          Area = (CongestionTaxProcessor.Enums.Area)1,
          TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)4,
          PassageTime = DateTime.Now,
          Cost = 45
      },
            new Passage
            {
                Id = 6,
                VehicleEventId = 6,
                Area = (CongestionTaxProcessor.Enums.Area)2,
                TaxBorder = (CongestionTaxProcessor.Enums.TaxBorder)4,
                PassageTime = DateTime.Now,
                Cost = 553
            }

      );
     }

    public static void VehiclesEventsSeed(this ModelBuilder builder)
           
    {
    


        builder.Entity<UserStopEvent>().HasData(
      
        new UserStopEvent
        {
         Id = 1,
         FromAddress = "Luftv�rnsv�gen, Gothenburg, SE",
         ToAddress = "Hantverksgatan, Kungsbacka, SE",
                StartTime = new DateTime(2022, 12, 01, 0, 0, 0, 0),
                ToDateTime = new DateTime(2023, 1, 28, 0, 0, 0, 0),
                Private = false,
                Distance = 2151,
                Driver = "Stefan Lunderbye",
                Type = Enums.VehicleEventType_V2.Stop,
                VehicleId = 1,
                PositionCount = 6,
                OdometerMeter = 521517,
                AccountId = 1,



        },  new UserStopEvent
        {
            Id = 2,
            FromAddress = "Munkeb�cksmotet, SE-415 05 G�teborg, Sverige",
            ToAddress = "Luftv�rnsv�gen, Gothenburg, SE",
            StartTime = new DateTime(2023, 1, 1, 0, 0, 0, 0),
            ToDateTime = new DateTime(2023, 1, 25, 0, 0, 0, 0),
            Private = false,
            Driver = "Stefan Lunderbye",
            Distance = 1855,
            PositionCount = 6,
            Type = Enums.VehicleEventType_V2.Trip,
            VehicleId = 1,
            OdometerMeter = 415341,
            AccountId = 1,
            PreviousId = 1


        }, 
        new UserStopEvent
        {
            Id = 3,
            FromAddress = "Munkeb�cksmotet, SE-415 05 G�teborg, Sverige",
            ToAddress = "Luftv�rnsv�gen, Gothenburg, SE",
            StartTime = new DateTime(2023, 1, 1, 3, 0, 0, 0),
            ToDateTime = new DateTime(2023, 1, 25, 0, 0, 0, 0),
            Private = false,
            Driver = "Stefan Lunderbye",
            Distance = 1755,
            PositionCount = 6,
            Type = Enums.VehicleEventType_V2.Stop,
            VehicleId = 1,
            OdometerMeter = 415341,
            AccountId = 1,
            PreviousId = 2

        }
        );
     }
    public static void VehiclesSeed(this ModelBuilder builder)
    {
        builder.Entity<Vehicle>().HasData(
         new Vehicle
         {
             VehicleId= 1,
             CustomerId = 1,
             CreatedOn= DateTime.Now,
             Name = "Stefans GL300M",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "GLM 300",
             Driver= "Stefan",
             OdometerMeter = 64487000,
             Co2 = 344,

         },
         new Vehicle
         {
             VehicleId= 2,
             CustomerId = 2,
             CreatedOn= DateTime.Now,
             Name = "Vit VW",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "BZH 698",
             Driver= "Thomas",
             OdometerMeter = 64487000,
             Co2 = 119,

         },
         new Vehicle
         {
             VehicleId= 3,
             CustomerId = 3,
             CreatedOn= DateTime.Now,
             Name = "DEMO - ID.3 - GL200",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "OAF84A",
             Driver= "Stefan",
             OdometerMeter = 64487000,
             Co2 = 99,

         },
          new Vehicle
         {
             VehicleId= 4,
             CustomerId = 4,
             CreatedOn= DateTime.Now,
             Name = "Audi Allroad",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "PSK 650",
             Driver= "Thomas",
             OdometerMeter = 64487000,
             Co2 = 253,

         },
          new Vehicle
         {
             VehicleId= 5,
             CustomerId = 5,
             CreatedOn= DateTime.Now,
             Name = "Opel",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "TJY 250",
             Driver= "Stefan",
             OdometerMeter = 64487000,
             Co2 = 777,

         },
          new Vehicle
         {
             VehicleId= 6,
             CustomerId = 6,
             CreatedOn= DateTime.Now,
             Name = "Rickardh HVT001",
             IsActive= true,
             IsDeleted= false,
             HasCongestionTax= true,
             HasExternalRouteSource = false,
             HasVehicleEventProcessor= true,
             VehicleRegistrationNumber = "YAS 421",
             Driver= "Thomas",
             OdometerMeter = 64487000,
             Co2 = 435,

         }
         );
     }
    public static void TrakkersEventsSeed(this ModelBuilder builder)
    {
            builder.Entity<TrakkerEvent>().HasData(
             new TrakkerEvent
            {
                TrakkerEventId = 1,
                TrakkerId = 1,
                OccuredOn = DateTime.UtcNow,
                TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                AlertTypeId = (Enums.AlertTypes)1,
                IsAgps = false,
                PositionId = 1,
                Altitude = (decimal)27.0,
                Heading = (decimal)290.0,
                Accuracy = 10,
                BatteryLevel = 80,
                Comment = "Any comment"

             },
             new TrakkerEvent
             {
                 TrakkerEventId = 2,
                 TrakkerId = 2,
                 OccuredOn = DateTime.UtcNow,
                 TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                 AlertTypeId = (Enums.AlertTypes)2,
                 IsAgps = false,
                 PositionId = 2,
                 Altitude = (decimal)27.0,
                 Heading = (decimal)290.0,
                 Accuracy = 5,
                 BatteryLevel = 80,
                 Comment = "Any comment"

             },
             new TrakkerEvent
            {
                TrakkerEventId = 3,
                TrakkerId = 3,
                OccuredOn = DateTime.UtcNow,
                TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                AlertTypeId = (Enums.AlertTypes)3,
                IsAgps = false,
                PositionId = 3,
                Altitude = (decimal)27.0,
                Heading = (decimal)290.0,
                Accuracy = 3,
                BatteryLevel = 30,
                Comment = "Any comment"

             },
             new TrakkerEvent
            {
                TrakkerEventId = 4,
                TrakkerId = 4,
                OccuredOn = DateTime.UtcNow,
                TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                AlertTypeId = (Enums.AlertTypes)7,
                IsAgps = false,
                PositionId = 4,
                Altitude = (decimal)27.0,
                Heading = (decimal)290.0,
                Accuracy = 4,
                BatteryLevel = 80,
                Comment = "Any comment"

             },
            new TrakkerEvent
            {
                TrakkerEventId = 5,
                TrakkerId = 5,
                OccuredOn = DateTime.UtcNow,
                TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                AlertTypeId = (Enums.AlertTypes)8,
                IsAgps = false,
                PositionId = 5,
                Altitude = (decimal)27.0,
                Heading = (decimal)290.0,
                Accuracy = 5,
                BatteryLevel = 80,
                Comment = "Any comment"

             },
            new TrakkerEvent
            {
                TrakkerEventId = 6,
                TrakkerId = 6,
                OccuredOn = DateTime.UtcNow,
                TrakkerEventTypeId = (Enums.TrakkerEventType)2,
                AlertTypeId = (Enums.AlertTypes)9,
                IsAgps = false,
                PositionId = 6,
                Altitude = (decimal)27.0,
                Heading = (decimal)290.0,
                Accuracy = 6,
                BatteryLevel = 80,
                Comment = "Any comment"

             }
            );
        
    }
    public static void AssetsEventsSeed(this ModelBuilder builder)
    {
        builder.Entity<AssetEvent>().HasData(new AssetEvent{
            AssetEventId= 1,
            AssetId = 1,
            PositionId = 1,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime= new DateTime(2021, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2021, 02, 09, 18, 44, 25),
            WorkOperationTime = new TimeSpan(863990000000),

        },
        new AssetEvent
        {
            AssetEventId = 2,
            AssetId = 2,
            PositionId = 2,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime = new DateTime(2022, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2022, 02, 09, 19, 44, 25),
            WorkOperationTime = new TimeSpan(5923070000),

        },
        new AssetEvent
        {
            AssetEventId = 3,
            AssetId = 3,
            PositionId = 3,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime = new DateTime(2020, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2020, 02, 09, 20, 44, 25),
            WorkOperationTime = new TimeSpan(863990000000),

        },
        new AssetEvent
        {
            AssetEventId = 4,
            AssetId = 4,
            PositionId = 4,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime = new DateTime(2019, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2019, 02, 09, 21, 44, 25),
            WorkOperationTime = new TimeSpan(863990000000),

        },
        new AssetEvent
        {
            AssetEventId = 5,
            AssetId = 5,
            PositionId = 5,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime = new DateTime(2018, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2018, 02, 09, 22, 44, 25),
            WorkOperationTime = new TimeSpan(863990000000),

        },
        new AssetEvent
        {
            AssetEventId = 6,
            AssetId = 6,
            PositionId = 6,
            AssetEventTypeId = (Enums.AssetEventType)1,
            StartDateTime = new DateTime(2017, 02, 09, 13, 44, 25),
            StopDateTime = new DateTime(2017, 02, 09, 23, 44, 25),
            WorkOperationTime = new TimeSpan(863990000000),

        }
        );

    }
        public static void AssetsSeed(this ModelBuilder builder)
    {
        builder.Entity<Asset>().HasData(
            new Asset
            {
             AssetId = 1,
             TrakkerId = 1,
             SecondsStillUntilStop = 0,
             OperationTimeCounter = 24735443,
            }
            ,new Asset
            {
                AssetId = 2,
                TrakkerId = 2,
                SecondsStillUntilStop = 0,
                OperationTimeCounter = 4516546,
            }
            , new Asset
             {
                 AssetId = 3,
                 TrakkerId = 3,
                 SecondsStillUntilStop = 0,
                 OperationTimeCounter = 4645453,
             }
             , new Asset
             {
                 AssetId = 4,
                 TrakkerId = 4,
                 SecondsStillUntilStop = 0,
                 OperationTimeCounter = 7468444,
             }
              , new Asset
              {
                  AssetId = 5,
                  TrakkerId = 5,
                  SecondsStillUntilStop = 0,
                  OperationTimeCounter = 68796655,
              }
              , new Asset
              {
                  AssetId = 6,
                  TrakkerId = 6,
                  SecondsStillUntilStop = 0,
                  OperationTimeCounter = 95656545,
              }
        );
    }

    public static void ScheduleEntriesSeed(this ModelBuilder builder)
    {
        builder.Entity<ScheduleEntry>().HasData(
            new ScheduleEntry
            {
                Id = 5739,
                StartTime = new TimeOnly(8, 0, 0),
                StopTime = new TimeOnly(17, 0, 0),
                ActiveDays = new DayOfWeek[] { DayOfWeek.Monday }.ToList(),
                ScheduleId = 3252

            },
            new ScheduleEntry
            {
                Id = 5740,
                StartTime = new TimeOnly(8, 0, 0),
                StopTime = new TimeOnly(17, 0, 0),
                ActiveDays = new DayOfWeek[] { DayOfWeek.Monday }.ToList(),
                ScheduleId = 3252

            }

        );
    }
    public static void TrakkersSeed(this ModelBuilder builder)
    {
        builder.Entity<Trakker>().HasData(
        new Trakker
        {
            TrakkerId = 1,
            CustomerId = 1,
            Name = "Stefans GL300M",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 1,
            ScheduleId = 3252,
            BatteryStatus = 77
           
         },
        new Trakker
        {
            TrakkerId = 2,
            CustomerId = 1,
            Name = "Vit VW",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 2,
            ScheduleId = 3252,
            BatteryStatus =  66
        },
        new Trakker
        {
            TrakkerId = 3,
            CustomerId = 1,
            Name = "DEMO - ID.3 - GL200",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 3,
            ScheduleId = 3252,
            BatteryStatus = 88

        },
        new Trakker
        {
            TrakkerId = 4,
            CustomerId = 1,
            Name = "Audi Allroad",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 4,
            ScheduleId = 3252,
            BatteryStatus = 66

        },
        new Trakker
        {
            TrakkerId = 5,
            CustomerId = 1,
            Name = "Opel",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 5,
            ScheduleId = 3252,
            BatteryStatus = 55

        },
        new Trakker
        {
            TrakkerId = 6,
            CustomerId = 1,
            Name = "Stefan HVT001",
            IconId = 1163,
            IsActive = true,
            IsDeleted = false,
            HardwareId = 6,
            ScheduleId = 3252,
            BatteryStatus = 33

        }
        );
   }
    public static void HardwareSeed(this ModelBuilder builder)
    {
        builder.Entity<Hardware>().HasData(new Hardware
          {
              HardwareId = 1,
              GlobalDeviceId = "015181000496795",
              Icc = "1234",
              OffGridThresholdSeconds = 604800,
              CustomerId = 1,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 2
          }, 
          new Hardware
          {
              HardwareId = 2,
              GlobalDeviceId = "867844001267007",
              Icc = "8934076179004688290",
              OffGridThresholdSeconds = 604800,
              CustomerId = 2,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 1
          },
          new Hardware
          {
              HardwareId = 3,
              GlobalDeviceId = "867844000257975",
              Icc = "89314404000460325617",
              OffGridThresholdSeconds = 604800,
              CustomerId = 3,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 1
          },
          new Hardware
          {
              HardwareId = 4,

              GlobalDeviceId = "352056090300266",
              Icc = "8935302170820298458",
              OffGridThresholdSeconds = 604800,
              CustomerId = 4,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 9
          },
          new Hardware
          {
              HardwareId = 5,
              GlobalDeviceId = "867844001266462",
              Icc = "8934076179004689330",
              OffGridThresholdSeconds = 604800,
              CustomerId = 5,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 1
          },
          new Hardware
          {
              HardwareId = 6,

              GlobalDeviceId = "352056090294543",
              Icc = "8935302170820298441",
              OffGridThresholdSeconds = 604800,
              CustomerId = 6,
              CustomerAdminId = 1,
              SentToCustomer = DateTime.UtcNow,
              HardwareTypeId = 9
          }

        );
    }

    public static void PositionsSeed(this ModelBuilder builder)
    {
        builder.Entity<Position>().HasData(new Position()
        {
            PositionId = 1,
            Latitude= (decimal)57.479664,
            Longitude = (decimal)12.069135,

        },
        new Position()
        {
            PositionId = 2,
            Latitude = (decimal)57.478383,
            Longitude = (decimal)12.062055,

        },
        new Position()
        {
            PositionId = 3,
            Latitude = (decimal)57.471641,
            Longitude = (decimal)12.054262,

        },
        new Position()
        {
            PositionId = 4,
            Latitude = (decimal)57.454088,
            Longitude = (decimal)12.090892,

        },
        new Position()
        {
            PositionId = 5,
            Latitude = (decimal)57.436401,
            Longitude = (decimal)12.136971,

        },
        new Position()
        {
            PositionId = 6,
            Latitude = (decimal)57.422616,
            Longitude = (decimal)12.155011,

        },
        new Position()
        {
            PositionId = 7,
            Latitude = (decimal)57.404432,
            Longitude = (decimal)12.149246,

        },
        new Position()
        {
            PositionId = 8,
            Latitude = (decimal)57.384202,
            Longitude = (decimal)12.129897,

        },
        new Position()
        {
            PositionId = 9,
            Latitude = (decimal)57.364143,
            Longitude = (decimal)12.11714,

        },
        new Position()
        {
            PositionId = 10,
            Latitude = (decimal)57.354805,
            Longitude = (decimal)12.107451,

        }
        );
    }
    public static void RootAccountSeed(this ModelBuilder builder)
    {
        builder.Entity<RootAccount>().HasData(new RootAccount()
        {
            RootAccountId = 1,
            RootAccountTypeId = 1,
            UserName = "owner@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq", // for password "abcd1234"
            CustomerAdminId = 1,
            IsLocked = false,

        });
    }

    public static void AccountsSeed(this ModelBuilder builder)
    {
        builder.Entity<Account>().HasData(new Account()
        { 
            AccountId = 1,
            AccountRoleId = 1, //  Owner Account
            Email = "owner@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 1,
            CustomerId= 1,
            LoginName = "owner@trakk.se"

        },
        new Account()
        {
            AccountId = 2,
            AccountRoleId = 2, //  Administrator Account
            Email = "administrator@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 2,
            CustomerId = 1,
            LoginName = "administrator@trakk.se"

        },
        new Account()
        {
            AccountId = 3,
            AccountRoleId = 3, //  User Account
            Email = "user@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 3,
            CustomerId = 1,
            LoginName = "user@trakk.se"

        },
        new Account()
        {
            AccountId = 4,
            AccountRoleId = 4, //  Driver Account
            Email = "driver@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 4,
            CustomerId = 1,
            LoginName = "driver@trakk.se"


        },
        new Account()
        {
            AccountId = 5,
            AccountRoleId = 5, // Guest Administrator
            Email = "guest@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 5,
            CustomerId = 1,
            LoginName = "guest@trakk.se",


        },
        new Account()
        {
            AccountId = 6,
            AccountRoleId = 6, // OnBorading Account
            Email = "onboarding@trakk.se",
            PasswordHash = "$2a$10$A7gP2yIPmRwNznbMDq4syeldrYaTo7bZEqzrBGK6dq/mlyxEDWwRq",// for password "abcd1234"
            IsEmailConfirmed = true,
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LanguageId = (int)Enums.Language.Svenska,
            ContactId = 6,
            CustomerId = 1,
            LoginName = "onboarding@trakk.se",

        }

        );
    }
    public static void ContactSeed(this ModelBuilder builder)
    {
        builder.Entity<Contact>().HasData(new Contact()
        {


            ContactId = 1,
            Name = "Owner Contact",
            Email = "owner@trakk.se",
            Number = "0000000",
            CustomerId= 1,
            


        },
        new Contact()
        {


            ContactId = 2,
            Name = "Administrator Contact",
            Email = "administrator@trakk.se",
            Number = "0000000",
            CustomerId = 2,



        },
        new Contact()
        {


            ContactId = 3,
            Name = "User Contact",
            Email = "user@trakk.se",
            Number = "0000000",
            CustomerId = 3,



        },
        new Contact()
        {


            ContactId = 4,
            Name = "Driver Contact",
            Email = "driver@trakk.se",
            Number = "0000000",
            CustomerId = 4,



        },
        new Contact()
        {


            ContactId = 5,
            Name = "Guest Contact",
            Email = "guest@trakk.se",
            Number = "0000000",
            CustomerId = 5,



        },
        new Contact()
        {


            ContactId = 6,
            Name = "Onboarding Contact",
            Email = "administrator@trakk.se",
            Number = "0000000",
            CustomerId = 6,



        }
        );
    }


    public static void CustomerAdminSeed(this ModelBuilder builder)
    {
        builder.Entity<CustomerAdmin>().HasData(new CustomerAdmin()
        {

            CustomerAdminId = 1,
            Name = "Admin Customer",
            ContactName = "Admin Customer",
            ContactEmail = "admincustomer@trakk.se"

        });
      }
    public static void CustomerSeed(this ModelBuilder builder)
    {
        builder.Entity<Customer>().HasData(new Customer()
        {

          CustomerId= 1,
          CustomerAdminId = 1,
          Name = "Customer #1",
          CreatedOn = DateTime.UtcNow,
          Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
          ZipCode = "42131",
          City =  "G�teborg", 
          Country = "Sweden"
        },
        new Customer()
        {

            CustomerId = 2,
            CustomerAdminId = 1,
            Name = "Customer #2",
            CreatedOn = DateTime.UtcNow,
            Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
            ZipCode = "42131",
            City = "G�teborg",
            Country = "Sweden"
        },
        new Customer()
        {

            CustomerId = 3,
            CustomerAdminId = 1,
            Name = "Customer #3",
            CreatedOn = DateTime.UtcNow,
            Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
            ZipCode = "42131",
            City = "G�teborg",
            Country = "Sweden"
        },
        new Customer()
        {

            CustomerId = 4,
            CustomerAdminId = 1,
            Name = "Customer #4",
            CreatedOn = DateTime.UtcNow,
            Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
            ZipCode = "42131",
            City = "G�teborg",
            Country = "Sweden"
        },
        new Customer()
        {

            CustomerId = 5,
            CustomerAdminId = 1,
            Name = "Customer #5",
            CreatedOn = DateTime.UtcNow,
            Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
            ZipCode = "42131",
            City = "G�teborg",
            Country = "Sweden"
        },
        new Customer()
        {

            CustomerId = 6,
            CustomerAdminId = 1,
            Name = "Customer #6",
            CreatedOn = DateTime.UtcNow,
            Address = "E A Rosengrens gata 19, V�stra Fr�lunda",
            ZipCode = "42131",
            City = "G�teborg",
            Country = "Sweden"
        }
        );
    }
    public static void GroupsSeed(this ModelBuilder builder)
    {
        builder.Entity<Group>().HasData(new Group()
        {
            GroupId = 1,
            CustomerId = 1,
            Name = "Nord",

        }
        );
    }
    public static void AccountGroupMapSeed(this ModelBuilder builder)
    {
        builder.Entity<Models.AccountGroupMap>().HasData(new Models.AccountGroupMap()
        {
            
            GroupId= 1,
            AccountId =1, // owner
            Access = true,

        }, new Models.AccountGroupMap()
        {

            GroupId = 1,
            AccountId = 2, // admin
            Access = true,

        },new Models.AccountGroupMap()
        {

            GroupId = 1,
            AccountId = 3, // user
            Access = true,

        },new Models.AccountGroupMap()
        {

            GroupId = 1,
            AccountId = 4, // driver
            Access = true,

        },
        new Models.AccountGroupMap()
        {

            GroupId = 1,
            AccountId = 5, // guest
            Access = true,

        },
        new Models.AccountGroupMap()
        {

            GroupId = 1,
            AccountId = 6, // onboard
            Access = true,

        }
        );
    }
    public static void TrakkerGroupMapSeed(this ModelBuilder builder)
    {
        builder.Entity<TrakkerGroupMap>().HasData(new TrakkerGroupMap()
        {
            GroupId = 1,
            TrakkerId = 1
      

        });
    }
    public static void ContactGroupMapSeed(this ModelBuilder builder)
    {
        builder.Entity<ContactGroupMap>().HasData(new ContactGroupMap()
        {
            GroupId = 1,
            ContactId = 1


        });
    }
    public static void GeofenceGroupMapSeed(this ModelBuilder builder)
    {
        builder.Entity<GeofenceGroupMap>().HasData(new GeofenceGroupMap()
        {
            GroupId = 1,
            GeofenceId = 1


        });
    }


    public static void SeedTrakkerGroupMap(this ModelBuilder builder)
    {
        builder.Entity<TrakkerGroupMap>().HasData(new TrakkerGroupMap()
        {
            GroupId = 1,
            TrakkerId= 1,

        }
        );
    }
    public static SmsOperator ToSmsOperator(this string name) =>
        name switch
        {
            "CSL" => new SmsOperator
            {
                SmsOperatorId = 1,
                Name = name,
                Apn = "Geminio2.com",
                User = "Guest",
                Password = "Guest"
            },
            "Vodafone" => new SmsOperator { SmsOperatorId = 2, Name = name, Apn = "trakk.m2m" },
            "Tre" => new SmsOperator { SmsOperatorId = 3, Name = name, Apn = "3iot.com" },
            _ => null
        };

    public static void SeedEnum<TEnum, TClass>(this ModelBuilder builder, Func<TEnum, TClass> createMethod) where TEnum : struct, Enum where TClass : class, new()
    {
        var e = EnumObject<TEnum>.ToList(createMethod);
        builder.Entity<TClass>().HasData(e);
    }
    
    public static void SeedLinkedEnum<TEnum, TClass, TMappedEnum, TMapClass>(
        this ModelBuilder builder, Func<TEnum, TClass> createMethod,
        Func<TEnum, TMappedEnum, TMapClass> createMapFunc,
         params (TEnum, TMappedEnum [])[] linkedEnums)
        where TEnum : struct, Enum where TClass : class, new() where TMapClass : class  where TMappedEnum : struct
    {
        var e = EnumObject<TEnum>.ToList(createMethod);
        builder.Entity<TClass>().HasData(e);
        var links = linkedEnums.SelectMany(x => x.Item2.Select(y => createMapFunc(x.Item1, y) ));
        builder.Entity<TMapClass>().HasData(links);
    }

    public static IEnumerable<CategoryType> DefaultCategories()
    {
        return new[]
        {
            new CategoryType { CategoryTypeId = 1, Name = "Machine type" },
            new CategoryType { CategoryTypeId = 2, Name = "Customer center" },
            new CategoryType { CategoryTypeId = 3, Name = "Project" },
            new CategoryType { CategoryTypeId = 4, Name = "Project number" },
            new CategoryType { CategoryTypeId = 5, Name = "Work sit" },
        };

    }
    public static void SeedIcons(this ModelBuilder builder)
    {
        builder.Entity<Icon>().HasData(new Icon[]
        {
            new Icon{IconId= 42, Name=  "trakk", Url = "icons/trakk/default.png"},
            new Icon{IconId=694, Name="black_cat", Url = "iconpack/animals/black_cat.png"},
            new Icon{IconId=695, Name="dalmatian_dog", Url = "iconpack/animals/dalmatian_dog.png"},
            new Icon{IconId=696, Name="dog", Url = "iconpack/animals/dog.png"},
            new Icon{IconId=697, Name="dogblack", Url = "iconpack/animals/dogblack.png"},
            new Icon{IconId=698, Name="frank", Url = "iconpack/animals/frank.png"},
            new Icon{IconId=699, Name="gnome-fish", Url = "iconpack/animals/gnome-fish.png"},
            new Icon{IconId=700, Name="horse", Url = "iconpack/animals/horse.png"},
            new Icon{IconId=701, Name="hypnotoad", Url = "iconpack/animals/hypnotoad.png"},
            new Icon{IconId=702, Name="kbugbuster", Url = "iconpack/animals/kbugbuster.png"},
            new Icon{IconId=703, Name="thunderbird", Url = "iconpack/animals/thunderbird.png"},
            new Icon{IconId=704, Name="turtle", Url = "iconpack/animals/turtle.png"},
            new Icon{IconId=705, Name="ammo-1", Url = "iconpack/cargo/ammo-1.png"},
            new Icon{IconId=706, Name="ammo-2", Url = "iconpack/cargo/ammo-2.png"},
            new Icon{IconId=707, Name="ammo-3", Url = "iconpack/cargo/ammo-3.png"},
            new Icon{IconId=708, Name="ammo-4", Url = "iconpack/cargo/ammo-4.png"},
            new Icon{IconId=709, Name="ammo-5", Url = "iconpack/cargo/ammo-5.png"},
            new Icon{IconId=710, Name="army-1", Url = "iconpack/cargo/army-1.png"},
            new Icon{IconId=711, Name="army-2", Url = "iconpack/cargo/army-2.png"},
            new Icon{IconId=712, Name="army-3", Url = "iconpack/cargo/army-3.png"},
            new Icon{IconId=713, Name="fork-1", Url = "iconpack/cargo/fork-1.png"},
            new Icon{IconId=714, Name="fork-2", Url = "iconpack/cargo/fork-2.png"},
            new Icon{IconId=715, Name="fork-3", Url = "iconpack/cargo/fork-3.png"},
            new Icon{IconId=716, Name="fork-4", Url = "iconpack/cargo/fork-4.png"},
            new Icon{IconId=717, Name="fork-5", Url = "iconpack/cargo/fork-5.png"},
            new Icon{IconId=718, Name="fork-6", Url = "iconpack/cargo/fork-6.png"},
            new Icon{IconId=719, Name="handle-1", Url = "iconpack/cargo/handle-1.png"},
            new Icon{IconId=720, Name="handle-2", Url = "iconpack/cargo/handle-2.png"},
            new Icon{IconId=721, Name="handle-3", Url = "iconpack/cargo/handle-3.png"},
            new Icon{IconId=722, Name="handle-4", Url = "iconpack/cargo/handle-4.png"},
            new Icon{IconId=723, Name="handle-5", Url = "iconpack/cargo/handle-5.png"},
            new Icon{IconId=724, Name="palet-01", Url = "iconpack/cargo/palet-01.png"},
            new Icon{IconId=725, Name="palet-02", Url = "iconpack/cargo/palet-02.png"},
            new Icon{IconId=726, Name="palet-03", Url = "iconpack/cargo/palet-03.png"},
            new Icon{IconId=727, Name="palet-04", Url = "iconpack/cargo/palet-04.png"},
            new Icon{IconId=728, Name="shelf-1", Url = "iconpack/cargo/shelf-1.png"},
            new Icon{IconId=729, Name="shelf-2", Url = "iconpack/cargo/shelf-2.png"},
            new Icon{IconId=730, Name="shelf-3", Url = "iconpack/cargo/shelf-3.png"},
            new Icon{IconId=731, Name="shipping-1", Url = "iconpack/cargo/shipping-1.png"},
            new Icon{IconId=732, Name="shipping-2", Url = "iconpack/cargo/shipping-2.png"},
            new Icon{IconId=733, Name="shipping-3", Url = "iconpack/cargo/shipping-3.png"},
            new Icon{IconId=734, Name="shipping-4", Url = "iconpack/cargo/shipping-4.png"},
            new Icon{IconId=736, Name="shipping-6", Url = "iconpack/cargo/shipping-6.png"},
            new Icon{IconId=737, Name="shipping-7", Url = "iconpack/cargo/shipping-7.png"},
            new Icon{IconId=738, Name="shipping-8", Url = "iconpack/cargo/shipping-8.png"},
            new Icon{IconId=739, Name="wood-1", Url = "iconpack/cargo/wood-1.png"},
            new Icon{IconId=740, Name="wood-2", Url = "iconpack/cargo/wood-2.png"},
            new Icon{IconId=741, Name="wood-3", Url = "iconpack/cargo/wood-3.png"},
            new Icon{IconId=742, Name="bag", Url = "iconpack/items/bag.png"},
            new Icon{IconId=743, Name="bicycle", Url = "iconpack/two weels/bicycle.png"},
            new Icon{IconId=744, Name="briefcase", Url = "iconpack/items/briefcase.png"},
            new Icon{IconId=745, Name="briefcase2-icoUrl = ", Url = "iconpack/items/briefcase2-icon.png"},
            new Icon{IconId=746, Name="business", Url = "iconpack/items/business.png"},
            new Icon{IconId=747, Name="checkered_flag", Url = "iconpack/items/checkered_flag.png"},
            new Icon{IconId=748, Name="iphone", Url = "iconpack/items/iphone.png"},
            new Icon{IconId=749, Name="mobile-phone", Url = "iconpack/items/mobile-phone.png"},
            new Icon{IconId=750, Name="safety-box-v2-icoUrl = ", Url = "iconpack/items/safety-box-v2-icon.png"},
            new Icon{IconId=751, Name="shanel-watch", Url = "iconpack/items/shanel-watch.png"},
            new Icon{IconId=752, Name="toolbox", Url = "iconpack/items/toolbox.png"},
            new Icon{IconId=753, Name="wheel", Url = "iconpack/items/wheel.png"},
            new Icon{IconId=754, Name="aik-stockholm", Url = "iconpack/logos and brands/aik-stockholm.png"},
            new Icon{IconId=755, Name="alfa-romeo", Url = "iconpack/logos and brands/alfa-romeo.png"},
            new Icon{IconId=756, Name="aston-martiUrl = ", Url = "iconpack/logos and brands/aston-martin.png"},
            new Icon{IconId=757, Name="audi", Url = "iconpack/logos and brands/audi.png"},
            new Icon{IconId=758, Name="barth", Url = "iconpack/logos and brands/barth.png"},
            new Icon{IconId=759, Name="bilia", Url = "iconpack/logos and brands/bilia.png"},
            new Icon{IconId=760, Name="bmw", Url = "iconpack/logos and brands/bmw.png"},
            new Icon{IconId=761, Name="bugatti", Url = "iconpack/logos and brands/bugatti.png"},
            new Icon{IconId=762, Name="djurgardens-if", Url = "iconpack/logos and brands/djurgardens-if.png"},
            new Icon{IconId=763, Name="ferrari", Url = "iconpack/logos and brands/ferrari.png"},
            new Icon{IconId=764, Name="halmstads-bk", Url = "iconpack/logos and brands/halmstads-bk.png"},
            new Icon{IconId=765, Name="hammarby-if", Url = "iconpack/logos and brands/hammarby-if.png"},
            new Icon{IconId=766, Name="helsingborg-if", Url = "iconpack/logos and brands/helsingborg-if.png"},
            new Icon{IconId=767, Name="if-elfsborg", Url = "iconpack/logos and brands/if-elfsborg.png"},
            new Icon{IconId=768, Name="ifk-goteborg", Url = "iconpack/logos and brands/ifk-goteborg.png"},
            new Icon{IconId=769, Name="kia", Url = "iconpack/logos and brands/kia.png"},
            new Icon{IconId=770, Name="lamborghini", Url = "iconpack/logos and brands/lamborghini.png"},
            new Icon{IconId=771, Name="logo_maUrl = ", Url = "iconpack/logos and brands/logo_man.png"},
            new Icon{IconId=772, Name="lotus", Url = "iconpack/logos and brands/lotus.png"},
            new Icon{IconId=773, Name="malmo-ff", Url = "iconpack/logos and brands/malmo-ff.png"},
            new Icon{IconId=774, Name="maserati", Url = "iconpack/logos and brands/maserati.png"},
            new Icon{IconId=775, Name="mazda", Url = "iconpack/logos and brands/mazda.png"},
            new Icon{IconId=776, Name="osters-if", Url = "iconpack/logos and brands/osters-if.png"},
            new Icon{IconId=777, Name="porsche", Url = "iconpack/logos and brands/porsche.png"},
            new Icon{IconId=778, Name="posteUrl = ", Url = "iconpack/logos and brands/posten.png"},
            new Icon{IconId=779, Name="posten_inv", Url = "iconpack/logos and brands/posten_inv.png"},
            new Icon{IconId=780, Name="saab", Url = "iconpack/logos and brands/saab.png"},
            new Icon{IconId=781, Name="sixt", Url = "iconpack/logos and brands/sixt.png"},
            new Icon{IconId=782, Name="skoda", Url = "iconpack/logos and brands/skoda.png"},
            new Icon{IconId=783, Name="suzuki", Url = "iconpack/logos and brands/suzuki.png"},
            new Icon{IconId=784, Name="team-swedeUrl = ", Url = "iconpack/logos and brands/team-sweden.png"},
            new Icon{IconId=785, Name="volvo", Url = "iconpack/logos and brands/volvo.png"},
            new Icon{IconId=786, Name="volvo_mark", Url = "iconpack/logos and brands/volvo_mark.png"},
            new Icon{IconId=787, Name="iron-man-core-red", Url = "iconpack/misc/iron-man-core-red.png"},
            new Icon{IconId=788, Name="iron-man-core-silver", Url = "iconpack/misc/iron-man-core-silver.png"},
            new Icon{IconId=789, Name="r2-d2", Url = "iconpack/misc/r2-d2.png"},
            new Icon{IconId=790, Name="bountyhunter-bobafett", Url = "iconpack/people/bountyhunter-bobafett.png"},
            new Icon{IconId=791, Name="bountyhunter-jangofett", Url = "iconpack/people/bountyhunter-jangofett.png"},
            new Icon{IconId=792, Name="clone-blue", Url = "iconpack/people/clone-blue.png"},
            new Icon{IconId=793, Name="clone-gray", Url = "iconpack/people/clone-gray.png"},
            new Icon{IconId=794, Name="clone-old", Url = "iconpack/people/clone-old.png"},
            new Icon{IconId=795, Name="clone-red", Url = "iconpack/people/clone-red.png"},
            new Icon{IconId=796, Name="clone-yellow", Url = "iconpack/people/clone-yellow.png"},
            new Icon{IconId=797, Name="darthvader", Url = "iconpack/people/darthvader.png"},
            new Icon{IconId=798, Name="female1", Url = "iconpack/people/female1.png"},
            new Icon{IconId=799, Name="female2", Url = "iconpack/people/female2.png"},
            new Icon{IconId=800, Name="female3", Url = "iconpack/people/female3.png"},
            new Icon{IconId=801, Name="female4", Url = "iconpack/people/female4.png"},
            new Icon{IconId=802, Name="female5", Url = "iconpack/people/female5.png"},
            new Icon{IconId=803, Name="female6", Url = "iconpack/people/female6.png"},
            new Icon{IconId=804, Name="iron-man-helmet-red", Url = "iconpack/people/iron-man-helmet-red.png"},
            new Icon{IconId=805, Name="iron-man-helmet-silver", Url = "iconpack/people/iron-man-helmet-silver.png"},
            new Icon{IconId=806, Name="male1", Url = "iconpack/people/male1.png"},
            new Icon{IconId=807, Name="male10", Url = "iconpack/people/male10.png"},
            new Icon{IconId=808, Name="male2", Url = "iconpack/people/male2.png"},
            new Icon{IconId=809, Name="male3", Url = "iconpack/people/male3.png"},
            new Icon{IconId=810, Name="male4", Url = "iconpack/people/male4.png"},
            new Icon{IconId=811, Name="male5", Url = "iconpack/people/male5.png"},
            new Icon{IconId=812, Name="male6", Url = "iconpack/people/male6.png"},
            new Icon{IconId=813, Name="male7", Url = "iconpack/people/male7.png"},
            new Icon{IconId=814, Name="male8", Url = "iconpack/people/male8.png"},
            new Icon{IconId=815, Name="male9", Url = "iconpack/people/male9.png"},
            new Icon{IconId=816, Name="optimus-prime", Url = "iconpack/people/optimus-prime.png"},
            new Icon{IconId=817, Name="2cv", Url = "iconpack/vehicle/2cv.png"},
            new Icon{IconId=818, Name="aston_martiUrl = ", Url = "iconpack/vehicle/aston_martin.png"},
            new Icon{IconId=819, Name="bugatti", Url = "iconpack/vehicle/bugatti.png"},
            new Icon{IconId=820, Name="cabriolet", Url = "iconpack/vehicle/cabriolet.png"},
            new Icon{IconId=821, Name="childhood_dream", Url = "iconpack/vehicle/childhood_dream.png"},
            new Icon{IconId=822, Name="chrysler", Url = "iconpack/vehicle/chrysler.png"},
            new Icon{IconId=823, Name="cool 66", Url = "iconpack/vehicle/cool 66.png"},
            new Icon{IconId=824, Name="cute_vehicle", Url = "iconpack/vehicle/cute_vehicle.png"},
            new Icon{IconId=825, Name="dodge_viper", Url = "iconpack/vehicle/dodge_viper.png"},
            new Icon{IconId=826, Name="dodge_viper2", Url = "iconpack/vehicle/dodge_viper2.png"},
            new Icon{IconId=827, Name="ferrari", Url = "iconpack/vehicle/ferrari.png"},
            new Icon{IconId=828, Name="fiat-topolino", Url = "iconpack/vehicle/fiat-topolino.png"},
            new Icon{IconId=829, Name="ford_gt", Url = "iconpack/vehicle/ford_gt.png"},
            new Icon{IconId=830, Name="ford_gt2", Url = "iconpack/vehicle/ford_gt2.png"},
            new Icon{IconId=831, Name="ford_mustang", Url = "iconpack/vehicle/ford_mustang.png"},
            new Icon{IconId=832, Name="ford_puma", Url = "iconpack/vehicle/ford_puma.png"},
            new Icon{IconId=833, Name="hyundai_coupe", Url = "iconpack/vehicle/hyundai_coupe.png"},
            new Icon{IconId=834, Name="jeep", Url = "iconpack/vehicle/jeep.png"},
            new Icon{IconId=835, Name="lamborghini", Url = "iconpack/vehicle/lamborghini.png"},
            new Icon{IconId=836, Name="lexus", Url = "iconpack/vehicle/lexus.png"},
            new Icon{IconId=837, Name="lotus", Url = "iconpack/vehicle/lotus.png"},
            new Icon{IconId=838, Name="mazda", Url = "iconpack/vehicle/mazda.png"},
            new Icon{IconId=839, Name="mercedes", Url = "iconpack/vehicle/mercedes.png"},
            new Icon{IconId=840, Name="mini_cooper", Url = "iconpack/vehicle/mini_cooper.png"},
            new Icon{IconId=841, Name="mitsubishi_lancer", Url = "iconpack/vehicle/mitsubishi_lancer.png"},
            new Icon{IconId=842, Name="motorboat", Url = "iconpack/vehicle/motorboat.png"},
            new Icon{IconId=843, Name="opel", Url = "iconpack/vehicle/opel.png"},
            new Icon{IconId=844, Name="orangecar", Url = "iconpack/vehicle/orangecar.png"},
            new Icon{IconId=845, Name="pagani", Url = "iconpack/vehicle/pagani.png"},
            new Icon{IconId=846, Name="porsche", Url = "iconpack/vehicle/porsche.png"},
            new Icon{IconId=847, Name="quad", Url = "iconpack/vehicle/quad.png"},
            new Icon{IconId=848, Name="sailing", Url = "iconpack/vehicle/sailing.png"},
            new Icon{IconId=849, Name="saleeUrl = ", Url = "iconpack/vehicle/saleen.png"},
            new Icon{IconId=850, Name="sport_car", Url = "iconpack/vehicle/sport_car.png"},
            new Icon{IconId=851, Name="spyker", Url = "iconpack/vehicle/spyker.png"},
            new Icon{IconId=852, Name="subaru", Url = "iconpack/vehicle/subaru.png"},
            new Icon{IconId=853, Name="suzuki", Url = "iconpack/vehicle/suzuki.png"},
            new Icon{IconId=854, Name="toyotagt-one", Url = "iconpack/vehicle/toyotagt-one.png"},
            new Icon{IconId=855, Name="utility-atv", Url = "iconpack/vehicle/utility-atv.png"},
            new Icon{IconId=856, Name="vegastrike", Url = "iconpack/vehicle/vegastrike.png"},
            new Icon{IconId=857, Name="vw", Url = "iconpack/vehicle/vw.png"},
            new Icon{IconId=858, Name="yellow_chevelot", Url = "iconpack/vehicle/yellow_chevelot.png"},
            new Icon{IconId=859, Name="black square", Url = "iconpack/minimal/sq_black.png"},
            new Icon{IconId=860, Name="blue square", Url = "iconpack/minimal/sq_blue.png"},
            new Icon{IconId=861, Name="gray square", Url = "iconpack/minimal/sq_bluegray.png"},
            new Icon{IconId=862, Name="blue square", Url = "iconpack/minimal/sq_blue.png"},
            new Icon{IconId=863, Name="bordeux square", Url = "iconpack/minimal/sq_bordeux.png"},
            new Icon{IconId=864, Name="brown square", Url = "iconpack/minimal/sq_brown.png"},
            new Icon{IconId=865, Name="cyan square", Url = "iconpack/minimal/sq_cyan.png"},
            new Icon{IconId=866, Name="darkpurple square", Url = "iconpack/minimal/sq_darkpurple.png"},
            new Icon{IconId=867, Name="gray square", Url = "iconpack/minimal/sq_gray.png"},
            new Icon{IconId=868, Name="green square", Url = "iconpack/minimal/sq_green.png"},
            new Icon{IconId=869, Name="indigo square", Url = "iconpack/minimal/sq_indigo.png"},
            new Icon{IconId=870, Name="lightred square", Url = "iconpack/minimal/sq_lightred.png"},
            new Icon{IconId=871, Name="lime square", Url = "iconpack/minimal/sq_lime.png"},
            new Icon{IconId=872, Name="orange square", Url = "iconpack/minimal/sq_orange.png"},
            new Icon{IconId=873, Name="pink square", Url = "iconpack/minimal/sq_pink.png"},
            new Icon{IconId=874, Name="purple square", Url = "iconpack/minimal/sq_purple.png"},
            new Icon{IconId=875, Name="red square", Url = "iconpack/minimal/sq_red.png"},
            new Icon{IconId=876, Name="yello square", Url = "iconpack/minimal/sq_yellow.png"},
            new Icon{IconId=877, Name="911 carerra", Url = "iconpack/vehicle/911_carrerra.png"},
            new Icon{IconId=878, Name="911 carrera 4", Url = "iconpack/vehicle/911_carrerra4.png"},
            new Icon{IconId=879, Name="911 carerrra 4 cab", Url = "iconpack/vehicle/911_carrerra4cab.png"},
            new Icon{IconId=880, Name="911 carerra 4s", Url = "iconpack/vehicle/911_carrerra4s.png"},
            new Icon{IconId=881, Name="911 carerra4s cab", Url = "iconpack/vehicle/911_carrerra4scab.png"},
            new Icon{IconId=882, Name="911 carerra cab", Url = "iconpack/vehicle/911_carrerracab.png"},
            new Icon{IconId=883, Name="911 careera gts", Url = "iconpack/vehicle/911_carrerragts.png"},
            new Icon{IconId=884, Name="911 carrerra gts cab", Url = "iconpack/vehicle/911_carrerragtscab.png"},
            new Icon{IconId=885, Name="911 carrerra s cab", Url = "iconpack/vehicle/911_carrerrascab.png"},
            new Icon{IconId=886, Name="911 gt2rs", Url = "iconpack/vehicle/911_gt2rs.png"},
            new Icon{IconId=887, Name="911 gt3", Url = "iconpack/vehicle/911_gt3.png"},
            new Icon{IconId=888, Name="911 gt3rs", Url = "iconpack/vehicle/911_gt3rs.png"},
            new Icon{IconId=889, Name="911 speedster", Url = "iconpack/vehicle/911_speedster.png"},
            new Icon{IconId=890, Name="911 targa", Url = "iconpack/vehicle/911_targa4.png"},
            new Icon{IconId=891, Name="911 targa 4s", Url = "iconpack/vehicle/911_targa4s.png"},
            new Icon{IconId=892, Name="911 turbo", Url = "iconpack/vehicle/911_turbo.png"},
            new Icon{IconId=893, Name="911 turbo cab", Url = "iconpack/vehicle/911_turbocab.png"},
            new Icon{IconId=894, Name="911 turbo s", Url = "iconpack/vehicle/911_turbos.png"},
            new Icon{IconId=895, Name="911 turbo s cab", Url = "iconpack/vehicle/911_turboscab.png"},
            new Icon{IconId=896, Name="porsche 1", Url = "iconpack/vehicle/porsche1.png"},
            new Icon{IconId=897, Name="porsche 2", Url = "iconpack/vehicle/porsche2.png"},
            new Icon{IconId=898, Name="porsche 3", Url = "iconpack/vehicle/porsche3.png"},
            new Icon{IconId=899, Name="porsche 4", Url = "iconpack/vehicle/porsche4.png"},
            new Icon{IconId=900, Name="porsche 5", Url = "iconpack/vehicle/porsche5.png"},
            new Icon{IconId=901, Name="porsche 6", Url = "iconpack/vehicle/porsche6.png"},
            new Icon{IconId=902, Name="porsche 7", Url = "iconpack/vehicle/porsche7.png"},
            new Icon{IconId=903, Name="porsche 8", Url = "iconpack/vehicle/porsche8.png"},
            new Icon{IconId=904, Name="porsche 9", Url = "iconpack/vehicle/porsche9.png"},
            new Icon{IconId=905, Name="porsche 10", Url = "iconpack/vehicle/porsche10.png"},
            new Icon{IconId=906, Name="porsche 11", Url = "iconpack/vehicle/porsche11.png"},
            new Icon{IconId=907, Name="porsche 12", Url = "iconpack/vehicle/porsche12.png"},
            new Icon{IconId=909, Name="plate-white", Url = "iconpack/plates/plate1.png"},
            new Icon{IconId=910, Name="plate-black", Url = "iconpack/plates/plate2.png"},
            new Icon{IconId=911, Name="plate-lightblue", Url = "iconpack/plates/plate3.png"},
            new Icon{IconId=912, Name="plate-lightgreeUrl = ", Url = "iconpack/plates/plate4.png"},
            new Icon{IconId=913, Name="plate-pink", Url = "iconpack/plates/plate5.png"},
            new Icon{IconId=914, Name="plate-yellow", Url = "iconpack/plates/plate6.png"},
            new Icon{IconId=915, Name="plate-blue", Url = "iconpack/plates/plate7.png"},
            new Icon{IconId=916, Name="plate-greeUrl = ", Url = "iconpack/plates/plate8.png"},
            new Icon{IconId=917, Name="plate-red", Url = "iconpack/plates/plate9.png"},
            new Icon{IconId=918, Name="chevrolet", Url = "iconpack/logos and brands/chevrolet.png"},
            new Icon{IconId=919, Name="citroeUrl = ", Url = "iconpack/logos and brands/citroen.png"},
            new Icon{IconId=920, Name="ford", Url = "iconpack/logos and brands/ford.png"},
            new Icon{IconId=921, Name="honda", Url = "iconpack/logos and brands/honda.png"},
            new Icon{IconId=922, Name="mercedes", Url = "iconpack/logos and brands/mercedes.png"},
            new Icon{IconId=923, Name="renault", Url = "iconpack/logos and brands/renault.png"},
            new Icon{IconId=924, Name="seat", Url = "iconpack/logos and brands/seat.png"},
            new Icon{IconId=925, Name="toyota", Url = "iconpack/logos and brands/toyota.png"},
            new Icon{IconId=926, Name="rib", Url = "iconpack/vehicle/rib.png"},
            new Icon{IconId=927, Name="sailboat 1", Url = "iconpack/vehicle/sailboat1.png"},
            new Icon{IconId=928, Name="sailboat 2", Url = "iconpack/vehicle/sailboat2.png"},
            new Icon{IconId=929, Name="sailboat 3", Url = "iconpack/vehicle/sailboat3.png"},
            new Icon{IconId=930, Name="sailboat 4", Url = "iconpack/vehicle/sailboat4.png"},
            new Icon{IconId=931, Name="sailboat 5", Url = "iconpack/vehicle/sailboat5.png"},
            new Icon{IconId=932, Name="badoo", Url = "iconpack/misc/badoo.png"},
            new Icon{IconId=933, Name="bebo", Url = "iconpack/misc/bebo.png"},
            new Icon{IconId=934, Name="blinklist", Url = "iconpack/misc/blinklist.png"},
            new Icon{IconId=935, Name="blogger", Url = "iconpack/misc/blogger.png"},
            new Icon{IconId=936, Name="brightkite", Url = "iconpack/misc/brightkite.png"},
            new Icon{IconId=937, Name="delicious", Url = "iconpack/misc/delicious.png"},
            new Icon{IconId=938, Name="designfloat", Url = "iconpack/misc/designfloat.png"},
            new Icon{IconId=939, Name="deviantart", Url = "iconpack/misc/deviantart.png"},
            new Icon{IconId=940, Name="digg", Url = "iconpack/misc/digg.png"},
            new Icon{IconId=941, Name="diigo", Url = "iconpack/misc/diigo.png"},
            new Icon{IconId=942, Name="dopplr", Url = "iconpack/misc/dopplr.png"},
            new Icon{IconId=943, Name="evernote", Url = "iconpack/misc/evernote.png"},
            new Icon{IconId=944, Name="facebook", Url = "iconpack/misc/facebook.png"},
            new Icon{IconId=945, Name="faves", Url = "iconpack/misc/faves.png"},
            new Icon{IconId=946, Name="flickr", Url = "iconpack/misc/flickr.png"},
            new Icon{IconId=947, Name="friendfeed", Url = "iconpack/misc/friendfeed.png"},
            new Icon{IconId=948, Name="friendster", Url = "iconpack/misc/friendster.png"},
            new Icon{IconId=949, Name="gamespot", Url = "iconpack/misc/gamespot.png"},
            new Icon{IconId=950, Name="google buzz", Url = "iconpack/misc/google_buzz.png"},
            new Icon{IconId=951, Name="google wave", Url = "iconpack/misc/google_wave.png"},
            new Icon{IconId=952, Name="google voice", Url = "iconpack/misc/google_voice.png"},
            new Icon{IconId=953, Name="grooveshark", Url = "iconpack/misc/grooveshark.png"},
            new Icon{IconId=954, Name="lastfm", Url = "iconpack/misc/lastfm.png"},
            new Icon{IconId=955, Name="linkediUrl = ", Url = "iconpack/misc/linkedin.png"},
            new Icon{IconId=956, Name="magnolia", Url = "iconpack/misc/magnolia.png"},
            new Icon{IconId=957, Name="mixx", Url = "iconpack/misc/mixx.png"},
            new Icon{IconId=958, Name="myspace", Url = "iconpack/misc/myspace.png"},
            new Icon{IconId=959, Name="netvibes", Url = "iconpack/misc/netvibes.png"},
            new Icon{IconId=960, Name="newsvine", Url = "iconpack/misc/newsvine.png"},
            new Icon{IconId=961, Name="orkut", Url = "iconpack/misc/orkut.png"},
            new Icon{IconId=962, Name="picasa", Url = "iconpack/misc/picasa.png"},
            new Icon{IconId=963, Name="reddit", Url = "iconpack/misc/reddit.png"},
            new Icon{IconId=964, Name="sharethis", Url = "iconpack/misc/sharethis.png"},
            new Icon{IconId=965, Name="stumbleupoUrl = ", Url = "iconpack/misc/stumbleupon.png"},
            new Icon{IconId=966, Name="technorati", Url = "iconpack/misc/technorati.png"},
            new Icon{IconId=967, Name="twitter", Url = "iconpack/misc/twitter.png"},
            new Icon{IconId=968, Name="vimeo", Url = "iconpack/misc/vimeo.png"},
            new Icon{IconId=969, Name="xing", Url = "iconpack/misc/xing.png"},
            new Icon{IconId=970, Name="yelp", Url = "iconpack/misc/yelp.png"},
            new Icon{IconId=971, Name="youtube", Url = "iconpack/misc/youtube.png"},
            new Icon{IconId=974, Name="trakk 006", Url = "iconpack/trakk/trakk006.png"},
            new Icon{IconId=975, Name="trakk 007", Url = "iconpack/trakk/trakk007.png"},
            new Icon{IconId=976, Name="trakk 009", Url = "iconpack/trakk/trakk009.png"},
            new Icon{IconId=977, Name="fiat", Url = "iconpack/logos and brands/fiat.png"},
            new Icon{IconId=978, Name="peugeot", Url = "iconpack/logos and brands/peugeot.png"},
            new Icon{IconId=979, Name="skoda 2", Url = "iconpack/logos and brands/skoda2.png"},
            new Icon{IconId=1104,Name="konica minolta", Url = "iconpack/logos and brands/konica-minolta.png"},
            new Icon{IconId=1105,Name="volkswageUrl = ", Url = "iconpack/logos and brands/volkswagen_logo.png"},
            new Icon{IconId=1106,Name="container beige", Url = "iconpack/cargo/containerbeige.png"},
            new Icon{IconId=1107,Name="container blue", Url = "iconpack/cargo/containerblue.png"},
            new Icon{IconId=1108,Name="container greeUrl = ", Url = "iconpack/cargo/containergreen.png"},
            new Icon{IconId=1109,Name="container orange", Url = "iconpack/cargo/containerorange.png"},
            new Icon{IconId=1110,Name="container red", Url = "iconpack/cargo/containerred.png"},
            new Icon{IconId=1111,Name="container white", Url = "iconpack/cargo/containerwhite.png"},
            new Icon{IconId=1112,Name="beige truck", Url = "iconpack/cargo/truckbeige.png"},
            new Icon{IconId=1113,Name="blue truck", Url = "iconpack/cargo/truckblue.png"},
            new Icon{IconId=1114,Name="green truck", Url = "iconpack/cargo/truckgreen.png"},
            new Icon{IconId=1115,Name="orange truck", Url = "iconpack/cargo/truckorange.png"},
            new Icon{IconId=1116,Name="red truck", Url = "iconpack/cargo/truckred.png"},
            new Icon{IconId=1117,Name="white truck", Url = "iconpack/cargo/truckwhite.png"},
            new Icon{IconId=1118,Name="honda motorcycle", Url = "iconpack/logos and brands/honda_motorcycle.png"},
            new Icon{IconId=1119,Name="hyundai", Url = "iconpack/logos and brands/hyundai1.png"},
            new Icon{IconId=1120,Name="hyundai 2", Url = "iconpack/logos and brands/hyundai2.png"},
            new Icon{IconId=1121,Name="nissaUrl = ", Url = "iconpack/logos and brands/nissan.png"},
            new Icon{IconId=1122,Name="opel", Url = "iconpack/logos and brands/opel.png"},
            new Icon{IconId=1123,Name="camper 1", Url = "iconpack/vehicle/camper1.png"},
            new Icon{IconId=1124,Name="camper 2", Url = "iconpack/vehicle/camper2.png"},
            new Icon{IconId=1125,Name="camper 3", Url = "iconpack/vehicle/camper3.png"},
            new Icon{IconId=1126,Name="camper 4", Url = "iconpack/vehicle/camper4.png"},
            new Icon{IconId=1127,Name="camper 5", Url = "iconpack/vehicle/camper5.png"},
            new Icon{IconId=1128,Name="caravan 1", Url = "iconpack/vehicle/caravan1.png"},
            new Icon{IconId=1129,Name="caravan 2", Url = "iconpack/vehicle/caravan2.png"},
            new Icon{IconId=1130,Name="caravan 3", Url = "iconpack/vehicle/caravan3.png"},
            new Icon{IconId=1131,Name="moped", Url = "iconpack/vehicle/moped.png"},
            new Icon{IconId=1132,Name="bicycle 1", Url = "iconpack/two weels/bicycle1.png"},
            new Icon{IconId=1133,Name="bicycle 2", Url = "iconpack/two weels/bicycle2.png"},
            new Icon{IconId=1134,Name="bicycle 3", Url = "iconpack/two weels/bicycle3.png"},
            new Icon{IconId=1135,Name="bicycle 4", Url = "iconpack/two weels/bicycle4.png"},
            new Icon{IconId=1136,Name="bicycle 5", Url = "iconpack/two weels/bicycle5.png"},
            new Icon{IconId=1137,Name="bicycle 6", Url = "iconpack/two weels/bicycle6.png"},
            new Icon{IconId=1138,Name="bicycle 7", Url = "iconpack/two weels/bicycle7.png"},
            new Icon{IconId=1139,Name="bicycle 8", Url = "iconpack/two weels/bicycle8.png"},
            new Icon{IconId=1140,Name="moped 1", Url = "iconpack/two weels/moped1.png"},
            new Icon{IconId=1141,Name="moped 2", Url = "iconpack/two weels/moped2.png"},
            new Icon{IconId=1142,Name="moped 3", Url = "iconpack/two weels/moped3.png"},
            new Icon{IconId=1143,Name="moped 4", Url = "iconpack/two weels/moped4.png"},
            new Icon{IconId=1144,Name="moped 5", Url = "iconpack/two weels/moped5.png"},
            new Icon{IconId=1145,Name="moped 6", Url = "iconpack/two weels/moped6.png"},
            new Icon{IconId=1146,Name="moped 7", Url = "iconpack/two weels/moped7.png"},
            new Icon{IconId=1147,Name="motorcross 1", Url = "iconpack/two weels/motorcross.png"},
            new Icon{IconId=1148,Name="motorcross 2", Url = "iconpack/two weels/motorcross2.png"},
            new Icon{IconId=1149,Name="motorcycle 1", Url = "iconpack/two weels/motorcycle1.png"},
            new Icon{IconId=1150,Name="motorcycle 2", Url = "iconpack/two weels/motorcycle2.png"},
            new Icon{IconId=1151,Name="motorcycle 3", Url = "iconpack/two weels/motorcycle3.png"},
            new Icon{IconId=1152,Name="motorcycle 4", Url = "iconpack/two weels/motorcycle4.png"},
            new Icon{IconId=1153,Name="motorcycle 5", Url = "iconpack/two weels/motorcycle5.png"},
            new Icon{IconId=1154,Name="motorcycle 6", Url = "iconpack/two weels/motorcycle6.png"},
            new Icon{IconId=1155,Name="motorcycle 7", Url = "iconpack/two weels/motorcycle7.png"},
            new Icon{IconId=1156,Name="motorcycle 8", Url = "iconpack/two weels/motorcycle8.png"},
            new Icon{IconId=1157,Name="motorcycle 9", Url = "iconpack/two weels/motorcycle9.png"},
            new Icon{IconId=1158,Name="motorcycle 10", Url = "iconpack/two weels/motorcycle10.png"},
            new Icon{IconId=1159,Name="motorcycle 11", Url = "iconpack/two weels/motorcycle11.png"},
            new Icon{IconId=1160,Name="yamaha fino scooter", Url = "iconpack/two weels/yamaha-fino-scooter.png"},
            new Icon{IconId=1161,Name="bird", Url = "iconpack/animals/bird.png"},
            new Icon{IconId=1162,Name="kitty", Url = "iconpack/animals/kitty.png"},
            new Icon{IconId=1163,Name="lioUrl = ", Url = "iconpack/animals/lion.png"},
            new Icon{IconId=1164,Name="tiger", Url = "iconpack/animals/tiger.png"},
            new Icon{IconId=1165,Name="boat engine 1", Url = "iconpack/items/boat engine1.png"},
            new Icon{IconId=1166,Name="boat engine 2", Url = "iconpack/items/boat engine2.png"},
            new Icon{IconId=1167,Name="boat engine 3", Url = "iconpack/items/boat engine3.png"},
            new Icon{IconId=1168,Name="boat engine 4", Url = "iconpack/items/boat engine4.png"},
            new Icon{IconId=1169,Name="akuma", Url = "iconpack/people/akuma.png"},
            new Icon{IconId=1170,Name="balrog", Url = "iconpack/people/balrog.png"},
            new Icon{IconId=1171,Name="barret", Url = "iconpack/people/barret.png"},
            new Icon{IconId=1172,Name="batmaUrl = ", Url = "iconpack/people/batman.png"},
            new Icon{IconId=1173,Name="benny boy", Url = "iconpack/people/benny_boy.png"},
            new Icon{IconId=1174,Name="beyond basic basement flood with napalm", Url = "iconpack/people/beyond_basic_basement_flood_with_napalm.png"},
            new Icon{IconId=1175,Name="black spidey", Url = "iconpack/people/black_spidey.png"},
            new Icon{IconId=1176,Name="blanka", Url = "iconpack/people/blanka.png"},
            new Icon{IconId=1177,Name="blue dr", Url = "iconpack/people/blue_dr.png"},
            new Icon{IconId=1178,Name="bumble starks", Url = "iconpack/people/bumble_starks.png"},
            new Icon{IconId=1179,Name="burn, ignorant creature!", Url = "iconpack/people/burn,_ignorant_creature!.png"},
            new Icon{IconId=1180,Name="capo", Url = "iconpack/people/capo!!.png"},
            new Icon{IconId=1181,Name="captain adama", Url = "iconpack/people/captain_adama.png"},
            new Icon{IconId=1182,Name="captain universe", Url = "iconpack/people/captain_universe.png"},
            new Icon{IconId=1183,Name="chun li", Url = "iconpack/people/chun_li.png"},
            new Icon{IconId=1184,Name="cloud", Url = "iconpack/people/cloud.png"},
            new Icon{IconId=1185,Name="colossus", Url = "iconpack/people/colossus.png"},
            new Icon{IconId=1186,Name="dhalsim", Url = "iconpack/people/dhalsim.png"},
            new Icon{IconId=1187,Name="dr", Url = "iconpack/people/dr.png"},
            new Icon{IconId=1188,Name="flying iron maUrl = ", Url = "iconpack/people/flying_iron_man.png"},
            new Icon{IconId=1189,Name="golrediroUrl = ", Url = "iconpack/people/golrediron.png"},
            new Icon{IconId=1190,Name="gordon tremeshco", Url = "iconpack/people/gordon_tremeshco.png"},
            new Icon{IconId=1191,Name="happy hulk", Url = "iconpack/people/happy_hulk.png"},
            new Icon{IconId=1192,Name="hellboy", Url = "iconpack/people/hellboy.png"},
            new Icon{IconId=1193,Name="hulkling", Url = "iconpack/people/hulkling.png"},
            new Icon{IconId=1194,Name="iron america", Url = "iconpack/people/iron_america.png"},
            new Icon{IconId=1195,Name="iron patriot", Url = "iconpack/people/iron_patriot.png"},
            new Icon{IconId=1196,Name="james bond beamers", Url = "iconpack/people/james_bond_beamers.png"},
            new Icon{IconId=1197,Name="johny blaze", Url = "iconpack/people/johny_blaze.png"},
            new Icon{IconId=1198,Name="johny cash", Url = "iconpack/people/johny_cash.png"},
            new Icon{IconId=1199,Name="keUrl = ", Url = "iconpack/people/ken.png"},
            new Icon{IconId=1200,Name="maghulk", Url = "iconpack/people/maghulk.png"},
            new Icon{IconId=1201,Name="magneto", Url = "iconpack/people/magneto.png"},
            new Icon{IconId=1202,Name="makoto", Url = "iconpack/people/makoto.png"},
            new Icon{IconId=1203,Name="maUrl = ", Url = "iconpack/people/man.png"},
            new Icon{IconId=1204,Name="method maUrl = ", Url = "iconpack/people/method_man.png"},
            new Icon{IconId=1205,Name="monger", Url = "iconpack/people/monger!.png"},
            new Icon{IconId=1206,Name="morales", Url = "iconpack/people/morales.png"},
            new Icon{IconId=1207,Name="motorcycle", Url = "iconpack/people/motorcycle.png"},
            new Icon{IconId=1208,Name="one", Url = "iconpack/people/one.png"},
            new Icon{IconId=1209,Name="ood", Url = "iconpack/people/ood.png"},
            new Icon{IconId=1210,Name="pete hornbeger", Url = "iconpack/people/pete_hornberger.png"},
            new Icon{IconId=1211,Name="pop champagne", Url = "iconpack/people/pop_champagne.png"},
            new Icon{IconId=1212,Name="red chin iron maUrl = ", Url = "iconpack/people/red_chin_iron_man.png"},
            new Icon{IconId=1213,Name="rulk", Url = "iconpack/people/rulk.png"},
            new Icon{IconId=1214,Name="ryu", Url = "iconpack/people/ryu.png"},
            new Icon{IconId=1215,Name="sakura", Url = "iconpack/people/sakura.png"},
            new Icon{IconId=1216,Name="serious", Url = "iconpack/people/serious.png"},
            new Icon{IconId=1217,Name="shadowcat", Url = "iconpack/people/shadowcat.png"},
            new Icon{IconId=1218,Name="silver surfer", Url = "iconpack/people/silver_surfer.png"},
            new Icon{IconId=1219,Name="smith", Url = "iconpack/people/smith.png"},
            new Icon{IconId=1220,Name="snake eyes", Url = "iconpack/people/snake_eyes.png"},
            new Icon{IconId=1221,Name="spider womaUrl = ", Url = "iconpack/people/spider_woman.png"},
            new Icon{IconId=1222,Name="spidey", Url = "iconpack/people/spidey.png"},
            new Icon{IconId=1223,Name="the canada one", Url = "iconpack/people/the_canada_one.png"},
            new Icon{IconId=1224,Name="thor", Url = "iconpack/people/thor.png"},
            new Icon{IconId=1225,Name="war machine", Url = "iconpack/people/war_machine.png"},
            new Icon{IconId=1226,Name="wariroUrl = ", Url = "iconpack/people/wariron.png"},
            new Icon{IconId=1227,Name="visioUrl = ", Url = "iconpack/people/vision.png"},
            new Icon{IconId=1228,Name="woody", Url = "iconpack/people/woody.png"},
            new Icon{IconId=1229,Name="zangief", Url = "iconpack/people/zangief.png"},
            new Icon{IconId=1230,Name="feeway", Url = "iconpack/items/freeway.png"},
            new Icon{IconId=1231,Name="parking", Url = "iconpack/items/parking.png"},
            new Icon{IconId=1232,Name="traffic light", Url = "iconpack/items/traffic-light.png"},
            new Icon{IconId=1233,Name="ride of hope cyaUrl = ", Url = "iconpack/logos and brands/ride_sticker_cyan.png"},
            new Icon{IconId=1234,Name="ride of hope greeUrl = ", Url = "iconpack/logos and brands/ride_sticker_green.png"},
            new Icon{IconId=1235,Name="ride of hope magenta", Url = "iconpack/logos and brands/ride_sticker_mag.png"},
            new Icon{IconId=1236,Name="ride of hope orange", Url = "iconpack/logos and brands/ride_sticker_orange.png"},
            new Icon{IconId=1237,Name="ride of hope black", Url = "iconpack/logos and brands/ride_sticker_black.png"},
            new Icon{IconId=1238,Name="ride of hope yellow", Url = "iconpack/logos and brands/ride_sticker_yellow.png"},
            new Icon{IconId=1239,Name="cksundet", Url = "iconpack/logos and brands/cksundet.png"},
            new Icon{IconId=1240,Name="tenson/51", Url = "iconpack/logos and brands/tenson-51.png"},
            new Icon{IconId=1241,Name="subaru", Url = "iconpack/logos and brands/subaru.png"},
            new Icon{IconId=1242,Name="trailer", Url = "iconpack/vehicle/trailer.png"},
            new Icon{IconId=1243,Name="volkswagen amarok", Url = "iconpack/vehicle/volkswagen_amarok.png"},
            new Icon{IconId=1244,Name="volkswagen caddy", Url = "iconpack/vehicle/volkswagen_caddy.png"},
            new Icon{IconId=1245,Name="volkswagen crafter-enclosed", Url = "iconpack/vehicle/volkswagen_crafter-enclosed.png"},
            new Icon{IconId=1246,Name="volkswagen crafter-opeUrl = ", Url = "iconpack/vehicle/volkswagen_crafter-open.png"},
            new Icon{IconId=1247,Name="volkswagen transporter", Url = "iconpack/vehicle/volkswagen_transporter.png"},
        });
    }
    public static string NormalizeName(this string src)
    {
        if (src.IsUppercase())
        {
            return src;
        }

        if (src.IsLowercase())
        {
            src = char.ToUpper(src[0]) + src[1..];
        }
        //split on uppercase
        if (src.SplitOnFirstPredicate( char.IsUpper, out var split))
        {
            src = string.Join(" ", split.Select(x => x.NormalizeName()));
        }

        return src;
    }

    private static bool SplitOnFirstPredicate(this string src, Func<char, bool> predicate, out IEnumerable<string> splitString)
    {
        var index = 1;
        while (index < src.Length)
        {
            if (predicate(src[index]))
            {
                splitString = new[]
                {
                    src[..index],
                    src[index..]
                };
                return true;
            }
            index++;
        }

        splitString = Array.Empty<string>();
        return false;
    }
    
    public static bool IsLowercase(this string src) => src.All(char.IsLower);
    public static bool IsUppercase(this string src) => src.All(char.IsUpper);
}