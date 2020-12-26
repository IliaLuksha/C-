USE [AdventureWorks]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[GetCarInfo] AS
BEGIN
	SELECT TOP 40
					CarId AS ID,
					Name AS CarName,
					YearProd,
					CarCountry,
					NewCost,
					CarGaranty
	FROM			DataCars.DataCars
END;