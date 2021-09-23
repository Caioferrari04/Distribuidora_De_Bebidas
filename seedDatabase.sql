USE [Distribuidora]
GO

INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Residencial')
GO
INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Comercial')
GO
INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Celular')
GO
INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Cobranca')
GO
INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Correspondencia')
GO
INSERT INTO [dbo].[Types]
           ([Name])
     VALUES
           ('Entrega')
GO

declare @CONTADOR int = 1

WHILE @CONTADOR < 101
BEGIN
	INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Email]
           ,[Password]
           ,[BirthDate]
           ,[Cep]
		   ,[Discriminator]
		   ,[Cpf]
		   ,[Rg])
     VALUES
           (CONCAT('Roberto', CAST(@CONTADOR AS varchar)),
		   CONCAT('a', CAST(@CONTADOR AS varchar), '@b.com'),
		   '' + @CONTADOR,
		   '2004-06-14',
		   ''+ @CONTADOR,
		   'UserPf',
		   '' + @CONTADOR + 1000,
		   '' + @CONTADOR + 2000)
	SET @CONTADOR = @CONTADOR + 1;
END;
GO

declare @V_CONTADOR int = 1

WHILE @V_CONTADOR < 101   
BEGIN
	INSERT INTO [dbo].[Phones] 
		([Number], [TypeOfId], [UserId])
		VALUES('' + @V_CONTADOR + 100, 2, @V_CONTADOR);
	INSERT INTO [dbo].[Addresses] 
		([Text], [TypeOfAddressId], [UserId])
		VALUES('' + @V_CONTADOR + 200, 2, @V_CONTADOR);
	SET @V_CONTADOR = @V_CONTADOR + 1;
END;
GO