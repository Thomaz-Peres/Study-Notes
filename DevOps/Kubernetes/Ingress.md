# O que o Ingress faz

O ingress vai fazer o papel de ter uma regra e entender qual a URL o usuario esta acessando e para qual service vai enviar o usuario onde estão os PODs especificados

![image](https://user-images.githubusercontent.com/95287311/182463908-ba0df06c-acf6-4fe2-aec7-18a6845afdf9.png)



como fiz o ingress funcionar no trampo:

```yaml
# https://kubernetes.io/docs/concepts/services-networking/ingress/#the-ingress-resource

apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: apis
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /$2
    nginx.ingress.kubernetes.io/ssl-redirect: "true"
    nginx.ingress.kubernetes.io/ssl-passthrough: "true"
    nginx.ingress.kubernetes.io/use-regex: "true"
    kubernetes.io/ingress.class: "nginx"
spec:
  rules:
  - http:
      paths:
      - path: /partner(/|$)(.*)
        pathType: Prefix
        backend:
          service:
            name: api-service
            port:
              number: 80
```
