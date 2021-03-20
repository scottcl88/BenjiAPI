SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddBackupSproc
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BACKUP DATABASE [BenjiDB] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\BenjiDB.bak' WITH NOFORMAT, NOINIT,  NAME = N'BenjiDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, NO_COMPRESSION,  STATS = 10, CHECKSUM
	
	declare @backupSetId as int
	select @backupSetId = position from msdb..backupset where database_name=N'BenjiDB' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N'BenjiDB' )
	if @backupSetId is null begin raiserror(N'Verify failed. Backup information for database ''BenjiDB'' not found.', 16, 1) end
	RESTORE VERIFYONLY FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\BenjiDB.bak' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
	
END


