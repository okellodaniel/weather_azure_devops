{{/*
Expand the name of the chart.
*/}}
{{- define "weather-api.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create a default fully qualified app name.
*/}}
{{- define "weather-api.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "weather-api.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "weather-api.labels" -}}
helm.sh/chart: {{ include "weather-api.chart" . }}
{{ include "weather-api.selectorLabels" . }}
{{- end }}

{{/*
Selector labels
*/}}
{{- define "weather-api.selectorLabels" -}}
app.kubernetes.io/name: {{ include "weather-api.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}