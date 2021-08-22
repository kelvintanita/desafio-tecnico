  ALTER TABLE Documento
  ADD DataCadastro DateTime2(7) NOT NULL DEFAULT(getdate())