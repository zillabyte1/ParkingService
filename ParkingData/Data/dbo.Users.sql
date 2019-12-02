USE [master]
GO

-- user: parkuser
-- pswd: test123

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [parkuser]    Script Date: 11/24/2019 11:04:42 AM ******/
CREATE LOGIN [parkuser] WITH PASSWORD=N'nhbvuR3tKnq0Qu4zD3tpQOIIaoXz1g9gNekp1KgzTMM=', DEFAULT_DATABASE=[parkdb], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [parkuser] DISABLE
GO

USE [parkdb]
GO

/****** Object:  User [parkuser]    Script Date: 11/24/2019 11:05:33 AM ******/
CREATE USER [parkuser] FOR LOGIN [parkuser] WITH DEFAULT_SCHEMA=[dbo]
GO


