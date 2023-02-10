-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS tickets(
        ticketId INT NOT NULL primary key,
        creatorId VARCHAR(255) NOT NULL,
        ticketname VARCHAR(255),
        ticketclient VARCHAR(255),
    )