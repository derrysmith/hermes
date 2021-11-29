# hermes

<!-- badges -->

A monorepository containing the applications, services, and libraries that make up the __hermes__ product suite. The __hermes__ repository contains:
- An Single Page Application built with NextJS
- A mobile hybrid application build with React Native
- A REST API built with ASP.NET Core.

## GCP

| project name | project id |
| :----------- | :--------- |
| derrysmith-hermes-prd | derrysmith-hermes-prd-19750430 |
| derrysmith-hermes-dev | derrysmith-hermes-dev-19750430 |
| derrysmith-hermes-sbx | derrysmith-hermes-sbx-19750430 |

```
|-- main
	|-- ci
		|-- TECH-123/admin-portal/feature-description
```

- merge `main` to `ci`
- create feature branch `JIRA-123/app-name/feature-description` from `ci`
- pull request feature branch to `ci`
- deploy `ci` branch to integrated environment
- do QA testing on integrated environment
- merge `ci` to `main`

## github.com/derrysmith/hermes - code

```
/-- .github
	/-- workflows
/-- mobile-app
	/-- src
/-- server-api
	/-- src
|-- .gitattributes
|-- .gitignore
|-- readme.md
```

## github.com/derrysmith/hermes - branches

```
|-- main
	|-- issues-0123/server-api/feature-name
	|-- hotfix-0124/server-api/defect-desc
```


## dev (integrated development environment)

kiira-health-dev

| service | image |
| :------ | :---- |
| admin-portal | us-west1-docker.pkg.dev/kiira-health-dev/admin-portal |
| admin-portal-api | us-west1-docker.pkg.dev/kiira-health-dev/admin-portal-api |
| kiira-io | us-west1-docker.pkg.dev/kiira-health-dev/kiira-io |
| identity-api | us-west1-docker.pkg.dev/kiira-health-dev/identity-api |
| identity-cli | us-west1-docker.pkg.dev/kiira-health-dev/identity-cli |
| platform-api | us-west1-docker.pkg.dev/kiira-health-dev/platform-cli |

us-west1-docker.pkg.dev/derrysmith-hermes-dev-19750430/hermes/server-api
### services

- admin-portal-api
- admin-portal-web
- 
- kiira-io
- kiira-io-api
- 
- identity-api
- platform-api
- payments-app

- kiira/services/identity
- kiira/services/platform
- kiira/services/payments

## sbx (pre-prod environment for smoke testing and demos)

kiira-health-sbx

## prd (production environment)

kiira-health-prd

derrysmith/hermes/server-api:local
derrysmith/hermes/server-api:latest
derrysmith/hermes/server-api:sandbox


kiira-health/kiira/admin-portal-web

kiira-health/kiira/service-identity:latest
kiira-health/kiira/service-platform:latest
kiira-health/kiira/service-payments:latest
kiira-health/kiira/service-commerce:latest

`derrysmith/hermes/server-api`

`derrysmith/hermes/client-web`

## installation

Instructions for how to build and run the three products locally.

### w/ Docker

```
$ docker compose ...
```

### w/ Visual Studio/VS Code

```
/-- derrysmith-hermes
	/-- client-api
	/-- client-web

	/-- mobile-api
	/-- mobile-app
		/-- anagrams
			/-- components
				|-- AnagramCard.tsx
				|-- AnagramList.tsx
			/-- screens
				|-- Anagrams.tsx
			/-- services
				|-- getAnagrams.ts
			|-- index.ts

	/-- server-api
```