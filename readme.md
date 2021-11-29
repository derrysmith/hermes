# hermes

<!-- badges -->
![server-api workflow](https://github.com/derrysmith/hermes/actions/workflows/server-api-gcr-deploy-dev.yml/badge.svg?branch=main)

## github.com/derrysmith/hermes - code

```
/-- derrysmith/hermes
	/-- client-api
	/-- client-web

	/-- mobile-api
	/-- mobile-app

	/-- server-api
		/-- src
			/-- Hermes.Server.Api

			/-- Hermes.Server.Api.Core.Games
			/-- Hermes.Server.Api.Core.Words

			/-- Hermes.Server.Api.Infrasturcture.Messaging
			/-- Hermes.Server.Api.Infrastructure.Persistence
		|-- server-api.sln
	/-- server-hub
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

- cut feature branch from `main`
- cut per-developer branch from feature branch
  - if feature requires multiple work branches, cut subsequent branches from feature branch
- merge per-developer feature branch(es) into feature branch
- on pr merge into feature branch, deploy to ci/dev environment
- perform qa on ci/dev environment
- pr/merge feature branch into `main`
- on pr merge into `main` branch, deploy to prod environment

```
|-- main
	|-- feature/[issue-number]/[description]
		|-- feature/[issue-number]/[description]/[developer-name]
	|-- hot-fix/[issue-number]/[description]
		|-- hot-fix/[issue-number]/[description]/[developer-name]

	|-- feature/123/add-json-file-provider
		|-- feature/123/add-json-file-provider/bootsy-collins
		|-- feature/123/add-json-file-provider/george-clinton
	|-- hot-fix/456/anagrams-returns-duplicates
		|-- hot-fix/456/anagrams-returns-duplicates/james-brown
```