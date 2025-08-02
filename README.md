# 🧙‍♂️ TesteWoWAPI

🎮 Aplicativo C# de Console para consumo da API do World of Warcraft, utilizando [Blizzard API](https://develop.battle.net/).

---

## 📦 Sobre o Projeto

Este projeto é um exemplo prático de como consumir a API do **World of Warcraft** com `RestSharp`, utilizando autenticação via **OAuth2** com `ClientID` e `ClientSecret`. Ele busca e exibe dados do jogo, como raças, classes e outras informações do universo WoW.

---

## 🛠️ Tecnologias Utilizadas

- 💻 **.NET Framework**
- 🔧 **RestSharp** - Para requisições HTTP
- 🧩 **Newtonsoft.Json** - Para manipulação de JSON
- ☁️ **Blizzard API** - Dados oficiais do World of Warcraft

---

## 🚀 Como Executar

1. 🔄 Clone o repositório:
   ```bash
   git clone https://github.com/JonasPassos/WoWAPI.git
   cd WoWAPI/TesteWoWAPI
🧰 Abra o projeto no Visual Studio

📝 Configure as credenciais da API Blizzard:

No arquivo Program.cs, substitua:

private const string ClientId = "YOUR_CLIENT";
private const string ClientSecret = "";

com suas credenciais válidas da Blizzard Developer Portal.

▶️ Execute o projeto

📄 Funcionalidades
🔐 Geração de token de acesso OAuth2

📥 Requisições autenticadas para a API WoW

🧙‍♀️ Exibição de dados como:

Raças jogáveis

Classes de personagem

Outras informações básicas

📸 Exemplo de Saída
Token de acesso gerado com sucesso!
Raças disponíveis:
- Humano
- Orc
- Elfo Noturno
...

  🤝 Contribuições
Sinta-se à vontade para abrir Issues ou Pull Requests. Toda ajuda é bem-vinda! 😄

📝 Licença
Este projeto é apenas para fins de estudo e demonstração. Para uso em produção, consulte a licença oficial da API da Blizzard.

📬 Contato
Desenvolvido por Jonas Passos 🧑‍💻


