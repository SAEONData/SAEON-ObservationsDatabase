Insert into OrganisationRole (Code,Name,Description,UserId) values('Owner','Owner','Owner role',(Select UserId from aspnet_Users where UserName = 'Tim'))
Insert into OrganisationRole (Code,Name,Description,UserId) values('Manager','Manager','Manager role',(Select UserId from aspnet_Users where UserName = 'Tim'))
Insert into OrganisationRole (Code,Name,Description,UserId) values('Funder','Funder','Funder role',(Select UserId from aspnet_Users where UserName = 'Tim'))
Insert into OrganisationRole (Code,Name,Description,UserId) values('DataProvider','Data provider','Data provider role',(Select UserId from aspnet_Users where UserName = 'Tim'))
Insert into OrganisationRole (Code,Name,Description,UserId) values('DataUser','Data user','Data user role',(Select UserId from aspnet_Users where UserName = 'Tim'))
