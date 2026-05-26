CREATE DATABASE IF NOT EXISTS clinica_db;
USE clinica_db;

CREATE TABLE pacientes (
    Id          INT AUTO_INCREMENT PRIMARY KEY,
    Nombre      VARCHAR(100) NOT NULL,
    Apellido    VARCHAR(100) NOT NULL,
    Edad        INT          NOT NULL,
    Rut         VARCHAR(20)  NOT NULL,
    Telefono    VARCHAR(20),
    TipoAtencion INT         NOT NULL,  
    TienePrevision TINYINT(1) NOT NULL,
    FechaAtencion DATE        NOT NULL,
    Diagnostico  VARCHAR(255)
);

Select * from pacientes;