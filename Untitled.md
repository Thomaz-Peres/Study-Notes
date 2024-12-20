---
title: "Running kubernetes locally with Kind"
date: "03/11/2024"
description: "A simple way to running kubernetes locally with Kind (and Lens)"
---

This isn't a tutorial about kubernetes, kind, or an API with .NET. It's just something that helped me when I was studying Kubernetes

#### Prerequisite tools needed

- [Kubernetes](https://kubernetes.io/)
- [Kind](https://kind.sigs.k8s.io/docs/user/quick-start/)
- [Docker](https://docs.docker.com/get-docker/)
- [.NET](https://dotnet.microsoft.com/en-us/download)

#### A brief context about kind

Kind is a tool for running local Kubernetes clusters using Docker containers.
_____________________________________

First, let's create a simple API with .NET. (Really simple, I won't change anything).

Run the following command in the terminal:

```
dotnet new webapi
```

Add the following Dockerfile:

```Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=80
COPY . ./
RUN dotnet restore api1.csproj
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "api1.dll"]
```

Run the following Docker command to create the image:

```
docker build -t api:1.0 .
```

To test the API, run:

```
docker run --rm -it -p 8001:80 -e ASPNETCORE_HTTP_PORTS=80 api:1.0

docker run --rm -it -p 8001:80 -e ASPNETCORE_HTTP_PORTS=80 api:1.0
```

Then run:

```
curl http://localhost:8001/weatherforecast
```
___

After creating the API and the Docker image, let's create a Cluster with the following YAML:

```yaml
kind: Cluster
apiVersion: kind.x-k8s.io/v1alpha4

nodes:
- role: control-plane
```

After creating the YAML, run the following command:

```
kind create cluster --name api --config=Cluster/DeployCluster.yaml
```

To check the cluster, run:

```
kubectl cluster-info -context kind-api
```

Next, we need to add the app image to the cluster with the command:

```
kind load docker-image api:1.0 --name api
```

Now, let's continue working with kubernetes by creating the *Deployment* and *Service* YAML files.

Deployment.yaml:

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: api
spec:
  selector:
    matchLabels:
      app: api
      version: v1
  replicas: 3
  template:
    metadata:
      labels:
        app: api
        version: v1
    spec:
      containers:
      - name: api
        image: api:1.0
        ports:
        - containerPort: 80
```

Service.yaml:

```yaml
apiVersion: v1
kind: Service
metadata:
  name: api-service
spec:
  selector:
    app: api
  ports:
  - name: api
    port: 80
    targetPort: 80
```

After creating the YAML files for the *Deployment* and *Service*, run the following commands:

```
kubectl apply -f Deployment.yaml

kubectl apply -f Service.yaml
```

You can check the services and deployments with `kubectl get deployments` and `kubectl get svc`.

When checking the **Services** you will see that there is no **External-IP** available, which is needed to call the endpoints in our API. This not a kubernetes or a kind problem but rather a docker issue. For an alternative solution, you can start from this [link](https://github.com/kubernetes-sigs/kind/issues/1200#issuecomment-647145134).

To connect your local computer to the Docker bridge default gateway, use the following `port-forward` command:

```
sudo -E kubectl port-forward svc/api-service 8001:80
```

Now, you can run:

```
curl http://localhost:8001/WeatherForecast
```

If you are running the .NET api, the response will look like this:

```json
[
    {
        "date": "2024-03-08T23:14:25.6202397+00:00",
        "temperatureC": 28,
        "temperatureF": 82,
        "summary": "Hot"
    },
    {
        "date": "2024-03-09T23:14:25.6202432+00:00",
        "temperatureC": 26,
        "temperatureF": 78,
        "summary": "Scorching"
    },
    {
        "date": "2024-03-10T23:14:25.6202433+00:00",
        "temperatureC": 44,
        "temperatureF": 111,
        "summary": "Hot"
    },
    {
        "date": "2024-03-11T23:14:25.6202435+00:00",
        "temperatureC": 8,
        "temperatureF": 46,
        "summary": "Warm"
    },
    {
        "date": "2024-03-12T23:14:25.6202437+00:00",
        "temperatureC": -10,
        "temperatureF": 15,
        "summary": "Warm"
    }
]
```

With this, you have a cluster running locally.

## Lens

[Lens](https://k8slens.dev/) is a tool to managing and troubleshooting Kubernetes workloads and many other things.

Let's start by installing Lens and logging in (you will need to create an account in lens and onstain a lens ID).

You can run the following command in the terminal:

```
k config view --output yaml
```

This command print your kubernetes configuration. We will need this to add to Lens. You can either connect the kube folder or copy the kube config and paste it (normally the config is found in `$HOME/.kube/config`).

With this, you will have the Cluster connection, and you can see something like this and many other things.

![Image lens 1](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/i8hft7xl3a3awy1d2eln.png)
![Image lens 2](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/wh28h1n5mf9dnk9hfefh.png)
