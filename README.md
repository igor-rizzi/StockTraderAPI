
## Comandos para Gerenciamento de Banco de Dados

### Adicionar Migration no Banco do Identity
```bash
dotnet ef migrations add InitialIdentityMigration --context StockTraderIdentityContext --startup-project ../StockTraderApi.API --output-dir Identity/Migrations
```

### Adicionar Migration no Banco da Aplicação
```bash
dotnet ef migrations add InitialIdentityMigration --context StockTraderDbContext --startup-project ../StockTraderApi.API --output-dir Context/Migrations
```

### Atualizar Banco do Identity
```bash
dotnet ef database update --context StockTraderIdentityContext --startup-project ../StockTraderApi.API
```

### Atualizar Banco da Aplicação
```bash
dotnet ef database update --context StockTraderDbContext --startup-project ../StockTraderApi.API
```

---

⚠️ **Observação:**  
Sempre execute os comandos a partir do diretório do projeto onde está a camada de `Infrastructure` (ou onde estão os `DbContext`).  
O `--startup-project` define qual projeto será usado como ponto de entrada para execução das migrations.

✅ Com esses comandos, você gerencia as migrations e atualizações de banco tanto para o contexto de autenticação (Identity) quanto para o contexto da aplicação.
