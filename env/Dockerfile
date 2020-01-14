FROM codercom/code-server:latest

USER root

WORKDIR /home/coder

RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN curl -sL https://deb.nodesource.com/setup_13.x | sudo -E bash -
RUN dpkg -i packages-microsoft-prod.deb

RUN apt-get install -y software-properties-common && add-apt-repository universe && apt-get update -y && sudo apt-get upgrade -y && apt-get install -y apt-transport-https dotnet-sdk-3.1 nodejs && npm install -g @angular/cli typescript

USER coder

RUN rm packages-microsoft-prod.deb

RUN code-server --install-extension ms-vscode.csharp
RUN code-server --install-extension angular.ng-template
RUN code-server --install-extension mrmlnc.vscode-scss

ENTRYPOINT ["dumb-init", "code-server", "/home/coder/project"]