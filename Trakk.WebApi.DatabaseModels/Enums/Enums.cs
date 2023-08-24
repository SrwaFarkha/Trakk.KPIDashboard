namespace Trakk.WebApi.Models
{
    public static class Enums
    {
        #region Database Enums
        public enum AlertTypes
        {
            SOS = 1,
            LowBattery,
            AGPS,
            Parking,
            OffGrid,
            PointOfInterest,
            ExitGeofence,
            EnterGeofence,
            IntersectGeofence,
            VehicleService,
            VehicleInspection,
            PowerOn,
            PowerOff,
            IgnitionOn,
            IgnitionOff,
            PowerSupplyOn,
            PowerSupplyOff,
            LowTemperature,
            HighTemperature,
            Temperature,
            AlcoholOk,
            AlcoholNotOk,
            Shake,
            Ping,
            Active,
            PowerCut,
            ACCON,
            ACCOFF,
            SquareSensitive,
        }

        public enum CommunicationEventType
        {
            Undefined,
            System,
            Email,
            SMS,
            WebHook,
            RSS,
            Twitter,
            Facebook
        }

        public enum Language
        {
            Undefined,
            English,
            Svenska
        }

        public enum GeofenceEventReportType
        {
            InsideGeofence = 1,
            OutsideGeofence,
        }

        public enum GeofenceType
        {
            Exit = 1,
            Enter,
            Intersect,
            Parking
        }

        public enum Services
        {
            Trakkers = 1,
            Assets,
            VehicleData,
            VehicleReminders,
            VehicleDrivingJournal,
            Geofence,
            Isa
        }

        public enum SpeedUnit
        {
            kmh,
            mph,
            knot
        }

        public enum TrakkerEventType
        {
            Position = 1,
            Alert,
            Parking,
            ConnectedToVehicle,
            DisconnectedFromVehicle,
            ConnectedToAsset,
            DisconnectedFromAsset,
            Ping,
            Active,
            Battery,
            Heartbeat,
            UserPosition,

        }

        public enum HardwareType
        {
            Undefined,
            GL200,
            GL300,
            GL300A,
            GMT100,
            GMT200,
            GV500,
            OB022,
            GL500M,
            HVT001,
            AT1,
            GT08,
            AT4,
            YABBY,
            OYSTER,
            PYXI,
            TaggrLarge,
            TaggrB,
            GL52LP,
            JM01,
            LL01,
            LL02,
            LG05,
            DebugPreciseTracker,
            VL103,
            SensativeVsmLora,
            LL303,
        }

        public enum AccountEventType
        {
            Undefined,
            Position = 1,
            Alert,
            LoggedIn,
            LoggedOut,
            RequestedPasswordRecovery,
            ChangedPassword,
            ConnectedToTrakker,
            DisconnectedFromTrakker
        }

        public enum AccountRight
        {
            UseMap = 1,
            UseTrakkers,
            UseVehicles,
            UseAssets,
            UseContacts,
            UseGroups,
            UseAccounts,
            UseMobileApp,
            UseSMS,
            UseEmail,
            UseSafetyZone
        }

        public enum AccountRole
        {
            AccountOwner = 1,
            AccountAdministrator,
            User,
            Driver,
            Guest,
            Onboarding
        }

        public enum CustomerFeature
        {
            SafetyZone = 1,
        }

        public enum CreateAccountRole
        {
            AccountOwner = AccountRole.AccountOwner,
            AccountAdministrator = AccountRole.AccountAdministrator,
            User = AccountRole.User,
            Onboarding = AccountRole.Onboarding
        }

        public enum VehicleEventType
        {
            Undefined = 0,
            UpdatedOdometer = 1,
            ChangedDriver,
            SentInspectionReminder,
            SentServiceReminder,
            Trip,
            Stop,
            ConnectedToTrakker,
            DisconnectedFromTrakker,
            WorkRelatedUse,
            PrivateUse,
            CongestionTaxPassage,
            ManualTrip,
            ManualStop
        }
        
        public enum VehicleEventType_V2
        {
            Trip,
            Stop,
            ManualTrip,
            ManualStop,
            CongestionTaxPassage
        }

        public enum DriverEventType
        {
            Automatic = 1,
            ManualStatusWork,
            ManualStatusLeisure,
            ConnectedToVehicle,
            DisconnectedFromVehicle
        }

        public enum RootAccountType
        {
            SuperUser = 1,
            ResellerUser,
            CustomerManager
        }

        public enum SmsOperator
        {
            CSL = 1,
            Vodafone,
            Tre
        }

        public enum HardwareStatus
        {
            Storage,
            Out,
            Deactivated
        }

        public enum VehicleReminderType
        {
            Inspection = 1,
            Service
        }

        public enum WorkingStatus
        {
            WorkRelatedUse = VehicleEventType.WorkRelatedUse,
            PrivateUse = VehicleEventType.PrivateUse
        }

        public enum JobType
        {
            VehicleInspection = 1,
            VehicleEventReport,
            VehicleService,
            VehicleServiceOnOdometer,
            TrakkerEventReport,
            InventoryReport,
            VehicleSummaryReport,
            AssetReport,
            AssetOperationTimeSummaryReport,
            AssetService,
            AssetReachedCounterValue,
            IsaEventReport,
            UnreasonableTrips,
            GeofenceEventReport,
            GeofenceEventSummaryReport
        }

        public enum JobIntervalType
        {
            Never = 1,
            Once,
            OnceAndDelete,
            Daily,
            DailyFullDay,
            Weekly,
            WeeklyFullWeek,
            Monthly,
            MonthlyFullMonth,
            Annually,
            AnnuallyFullYear,
            Repeat
        }

        public enum AssetEventType
        {
            OperationTime = 1,
            ManualCounterReset,
            SentOperationTimeReminder,
            IncompleteOperationTimeEvent
        }

        #endregion

        #region Search Filter Enums
        public enum AccountInclude
        {
            information = 1,
            services,
            rights,
            all
        }

        public enum ConnectionsInclude
        {
            assets = 1,
            geofences,
            groups,
            mapzones,
            trakkers,
            accounts,
            vehicles,
            latestPosition,
            all
        }

        public enum ObjectType
        {
            Undefined = 0,
            Account = 1,
            Asset,
            Contact,
            Geofence,
            System,
            Trakker,
            Vehicle
        }
        #endregion

        public enum GeometryType
        {
            Point,
            MultiPoint,
            LineString,
            MultiLineString,
            Polygon,
            MultiPolygon,
        }

        public enum ApiErrorCode
        {
            NotFound,
            GeoJson,
            ValidationFailed,
            EmailAlreadyRegistered,
            NullHttpBody,
            IncorrectPassword,
            PasswordRecoveryUsed,
            PasswordRecoveryExpired,
            ServiceAlreadyRegistered,
            ResourceAlreadyConnected,
            ConnectionDoesNotExist,
            UserNameTaken,
            EmailNotConfirmed,
            TokenAlreadyUsed,
            LoginFailed,
            GlobalDeviceIdTaken,
            IccTaken,
            HardwareNotAvailable,
            HardwareNotFound,
            HardwareIsNotConnectedToTrakker,
            TrakkerNotAvailable,
            GeofenceNotAvailable,
            ContactNotAvailable,
            IconNotFound,
            AccountNotAvailable,
            TrakkerEventNotAvailable,
            CustomerNotAvailable,
            GroupNameTaken,
            GroupNotAvailable,
            GroupRequired,
            CantAssignRole,
            UnauthorizedRole,
            OneAccountOwnerRequired,
            NegativeBufferRadius,
            IntParseError,
            NullBufferRadius,
            NullGeometry,
            ScheduleNotAvailable,
            CronPage,
            AlertNotAvailable,
            TimeZoneNotFound,
            PositionAlreadyGeocoded,
            GeocodeError,
            CustomerLocked,
            AccountExpired,
            CustomerAdminNotFound,
            TrakkerNotFound,
            TicketNotFound,
            TicketUsed,
            TicketExpired,
            RootAccountLocked,
            VehicleNotAvailable,
            NoRecipients,
            EmailNotSent,
            VehicleEventNotAvailable,
            MismatchedTrips,
            TripStartMismatch,
            TripsBetweenMerge,
            TripNotFinished,
            VehicleEventIdMismatch,
            NullOdometer,
            NoPosition,
            VehicleEventNotTrip,
            InvalidDateTimeRange,
            HighAvgKmh,
            WrongVehicleEventType,
            NoVehicleEvents,
            TrakkersNotFound,
            VehiclesNotFound,
            JobNotFound,
            AssetEventNotAvailable,
            AssetNotAvailable,
            NoAssetEvents,
            NoTrakkerEvents,
            CustomerNotConnectedToTrakker,
            LoginNameAlreadyRegistered,
            CantUseEmail,
            ContactConnectedToAccount,
            CategoryTypeNotFound,
            CategoryNameTaken,
            CategoryNotFound,
            SalesPersonNameTaken,
            AtLeastOnePropertyIsRequired,
            CustomerHasUnits,
            CustomerHasHardware,
            NotDateTime,
            InvalidModel,
            EquipmentNumberNotAvailable,
            CustomerAlreadyExist,
            InvalidCoordinates
        }

        public enum SqlErrorId
        {
            DuplicatePrimaryKey = 1062
        }

        public enum TrakkerConnection
        {
            Geofence,
            Vehicle,
            Contact
        }

        public enum Connection
        {
            Contact,
            Geofence,
            Trakker
        }

        public enum TrakkerSearchCategory
        {
            Name,
            TrakkerId,
            CustomerId,
            GlobalDeviceId
        }

        public enum HardwareSearchCategory
        {
            GlobalDeviceId,
            HardwareId
        }

        public enum FileExtension
        {
            Excel,
            Pdf
        }

        public enum CustomerSearchCategory
        {
            CustomerId,
            CustomerName
        }

        public enum SearchCategory
        {
            All,
            Customer,
            Trakker,
            Hardware,
            Account,
            Filter,
            Vehicle,
            Asset,
            Unit
        }

        public enum FilterCategory
        {
            All,
            NewCustomers,
            OldCustomers,
            LockedCustomers,
            LockedAccounts,
            ArchivedTrakkers,
            DeactivatedHardware,
            StockedHardware,
            CustomerUnits,
            CustomerTrakkers,
            CustomerAccounts,
            CustomerVehicles,
            VehicleFreeCustomerTrakkers,
            UnitsWithoutHardware,
            Units,
            CustomerHardware,
            CustomerHardwareInStock,
            CustomerHardwareInUse
        }

        public enum TrakkerStatus
        {
            NewTrakker,
            OffGrid,
            Active,
            Idle,
            Moving,
            PoweredOff,
            PoweredOn,
            Parked
        }

        public enum PositionPrivacy
        {
            WorkRelatedUseWithAddress,
            PrivateUseWithAddressHidden,
            PrivateUseWithAddress,
            AllWithAddress,
            AllWithPrivateAddressHidden
        }

        public enum SortOrder
        {
            Ascending,
            Descending
        }

        public enum DriverAssignment
        {
            NotAssigned,
            OneTrip,
            ValidForTime,
            Permanent,
        }

        public enum FuelType
        {
            Undefined,
            Petrol,
            Diesel,
            E85,
            Electric,
            Gas,
            Hvo100 
        }

        public enum BillingType
        {
            Undefined,
            Billable,
            NotBillable,
            Demo,
            Returning,
            Reserved1,
            Reserved2
        }

        public enum FinancePartner
        {
            Undefined,
            None,
            Leaseplan,
            Arval,
            Trakk,
            Ramirent,
            Rentsafe,
            Reserved3
        }
    }
}
