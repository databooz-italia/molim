INSERT INTO molim_v2.profili
(
SELECT * FROM molim.profili
);

INSERT INTO molim_v2.accounts
(
SELECT * FROM molim.Accounts
);

INSERT INTO molim_v2.permessi_profili
(
SELECT * from molim.permessiprofili
);

INSERT INTO molim_v2.patologie
(
SELECT * from molim.progetti
);

INSERT INTO molim_v2.tipi_esami
(
SELECT idtipotest, 'NAD', descrizione, 1, 1, creatoraccount_id, updateraccount_id, creationdate, lastupdatedate from molim.tipitest
);

SELECT ID, idtest, idprogetto, tipovalore, CASE WHEN IdTipoTest = 'NEURO' AND IdClusterTest = 'COGNT' THEN 'NEUCO' WHEN IdTipoTest = 'NEURO' AND IdClusterTest = 'MOTOR' THEN 'NEUMO' ELSE 'RADIO' END, descrizione, DataInizioValidita,  datafinevalidita, valoremin, valoremax, regex, creatoraccount_id, updateraccount_id, creationdate, lastupdatedate from molim.progettitest;

INSERT INTO molim_v2.features
(
SELECT ID, idtest, idprogetto, tipovalore, CASE WHEN IdTipoTest = 'NEURO' AND IdClusterTest = 'COGNT' THEN 'NEUCO' WHEN IdTipoTest = 'NEURO' AND IdClusterTest = 'MOTOR' THEN 'NEUMO' ELSE 'RADIO' END, descrizione, DataInizioValidita,  datafinevalidita, valoremin, valoremax, regex, creatoraccount_id, updateraccount_id, creationdate, lastupdatedate from molim.progettitest
);

UPDATE molim_v2.features set Descrizione = CONCAT(CASE WHEN IdTipoEsame = 'NEUCO' THEN 'COG - ' WHEN idTipoEsame = 'NEUMO' THEN 'MOT - ' ELSE '' END, Descrizione);
UPDATE molim_v2.features Set IdTipoEsame = 'NEURO' WHERE IdTipoEsame in ('NEUCO', 'NEUMO');

INSERT INTO molim_v2.normalizzazione_features
(
SELECT * FROM molim.normalizzazionerisultatitest
);

INSERT INTO molim_v2.pazienti
(
SELECT * FROM molim.pazienti
);

INSERT INTO molim_v2.esami
(
SELECT idesitotestpaziente, idpaziente, IdProgetto, idtipotest, data, creatoraccount_id, updateraccount_id, creationdate, lastupdatedate from molim.esititestpazienti
);

insert into molim_v2.features_esame
(
SELECT idesitotestpaziente, idprogettotest, null, valore, creatoraccount_id, updateraccount_id, creationdate, lastupdatedate from molim.dettagliesititestpazienti
);
