🌱 EnergiaConsciente - Plataforma de Monitoramento e Redução de Consumo de Energia ⚡️


Solução inovadora que utiliza IoT, IA e Computação em Nuvem para otimizar o consumo de energia, reduzir custos e promover a sustentabilidade.

📌 Descrição do Projeto
EnergiaConsciente é uma plataforma inteligente de monitoramento e redução de consumo de energia, projetada para residências, empresas e indústrias. Utilizando tecnologias avançadas como a Internet das Coisas (IoT), Inteligência Artificial (IA) e computação em nuvem, a plataforma permite que os usuários otimizem o uso de energia, reduzam custos e minimizem o impacto ambiental.

A plataforma oferece:

Monitoramento em tempo real do consumo de energia.
Alertas sobre picos de consumo e recomendações personalizadas.
Controle remoto de dispositivos para otimização do uso de energia.
Insights baseados em IA para reduzir o desperdício e otimizar o consumo.
Acessibilidade via aplicativo móvel com interface intuitiva e amigável.
Recompensas por comportamentos sustentáveis e eficientes.

🎯 Objetivo
O objetivo da EnergiaConsciente é fornecer uma solução eficaz para o monitoramento e redução do consumo de energia, permitindo que os usuários, sejam eles residenciais, empresariais ou industriais, façam um uso mais eficiente dos recursos, reduzindo os custos operacionais e contribuindo para um futuro mais sustentável. A plataforma visa engajar os usuários com dados precisos e recomendações inteligentes para práticas mais conscientes de consumo energético.

💡 Funcionalidades
Monitoramento em Tempo Real: Acompanhe o consumo de energia em tempo real, com dados detalhados sobre cada aparelho ou ambiente.
Alertas de Picos de Consumo: Notificações para informar sobre picos de consumo e possíveis desperdícios de energia.
Recomendações Personalizadas: Sugestões baseadas em inteligência artificial para otimizar o uso de energia e reduzir custos.
Controle Remoto de Dispositivos: Desligue ou ajuste o consumo de dispositivos quando não estiverem em uso.
Insights para Redução de Desperdício: Utilize IA para analisar padrões de consumo e otimizar as operações.
Engajamento Sustentável: Recompensas para usuários que adotam práticas energéticas mais eficientes e sustentáveis.
🗂️ Estrutura do Projeto
📂 Pasta API
Controller: Gerencia as requisições HTTP e coordena as operações de monitoramento e controle remoto dos dispositivos.
Models: Representações dos objetos principais, como Usuario, Dispositivo, Consumo, Recomendacao.
Services/Repository: Implementações da lógica de negócio para monitoramento de consumo, controle de dispositivos e recomendações personalizadas.
📂 Pasta Documentação
Documentação técnica detalhada sobre a API, incluindo endpoints, parâmetros e exemplos de uso, configurado com Swagger para facilitar a interação.
📂 Pasta Testes
Contém testes unitários para garantir que todos os processos de monitoramento, controle e recomendações funcionem corretamente.
🤖 Inteligência Artificial para Otimização de Consumo
A plataforma utiliza Machine Learning para analisar os padrões de consumo e oferecer recomendações personalizadas aos usuários, ajudando-os a reduzir o desperdício e economizar energia. A IA realiza análises preditivas e fornece insights sobre quais dispositivos devem ser ajustados para um consumo mais eficiente.

🧪 Testes Implementados
1. Testes de Uusario
A classe UsuarioTests testa as funcionalidades de login do usuario, garantindo que os dados do susario sejam unicos e coerentes.


🛠️ Tecnologias Utilizadas
🔧 Ferramentas e Frameworks


📚 Bibliotecas e Ferramentas
ASP.NET Core: Para o desenvolvimento da API.
IoT Frameworks: Para a conectividade dos dispositivos.
Azure: Para a infraestrutura em nuvem e escalabilidade.
Swagger: Para documentação e testes dos endpoints da API.
ML.NET: Para a implementação de algoritmos de machine learning e recomendação de otimização do consumo.
SignalR: Para atualização em tempo real de dados de consumo.
🚀 Como Executar o Projeto
Siga estas etapas para configurar e executar a aplicação localmente:

Clone o repositório:

bash
Copiar código
git clone https://github.com/
Navegue até o diretório do projeto:

bash
Copiar código
cd EnergiaConsciente
Instale as dependências:

bash
Copiar código
dotnet restore
Configure a string de conexão no appsettings.json:

Atualize a string de conexão para o seu banco de dados (se aplicável).
Execute a aplicação:

bash
Copiar código
dotnet run
Acesse a documentação da API via Swagger: Abra o navegador e vá até: https://localhost:5001/swagger/index.html.

📊 Estrutura de Dados
Usuario: Armazena informações do usuário e suas credenciais.
Dispositivo: Contém informações sobre dispositivos conectados à plataforma, como tipo e consumo.
Consumo: Registra dados de consumo energético em tempo real.
Recomendacao: Armazena as recomendações geradas pela IA para otimizar o consumo de energia.
💻 Requisitos
Visual Studio 2022
.NET 8
Azure
Git
📈 Roadmap
Monitoramento de Consumo em Tempo Real: Melhorar o tempo de resposta e precisão dos dados.
Expansão de Dispositivos Conectados: Integrar mais dispositivos e plataformas de IoT.
Melhorias na IA: Aprofundar o algoritmo de recomendação para oferecer sugestões ainda mais precisas.
<a href="#top">Voltar ao topo</a>

