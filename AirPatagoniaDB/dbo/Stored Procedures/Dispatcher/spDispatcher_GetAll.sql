CREATE PROCEDURE [dbo].[spDispatcher_GetAll]
AS
BEGIN
	SELECT * from dispatcher WHERE  active = 1
END
