-- Active: 1678299152493@@SG-copy-bugle-5822-7314-mysql-master.servers.mongodirector.com@3306@Tickets

CREATE TABLE
    IF NOT EXISTS ticket(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(255) NOT NULL,
        ticketname VARCHAR(255) NOT NULL,
        ticketclient VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';