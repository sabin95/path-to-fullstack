FROM ubuntu:latest

RUN apt-get update -y && \
    apt-get upgrade -y && \
    apt-get install -y software-properties-common curl && \
    curl https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb --output packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    add-apt-repository universe && \
    curl -sL https://deb.nodesource.com/setup_13.x | bash - && \
    apt-get install -y apt-transport-https dotnet-sdk-3.1 nodejs && \
    npm install -g @angular/cli typescript

COPY ./start.sh /home/start.sh
RUN chmod +x /home/start.sh

EXPOSE 5000 5001 4200

ENTRYPOINT sleep infinity

# ENTRYPOINT ["/home/start.sh"]