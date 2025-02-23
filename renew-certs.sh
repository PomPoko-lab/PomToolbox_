#!/bin/bash

# Variables
DOMAIN="app.pompoko.dev"
CERT_DIR="/etc/letsencrypt/live/$DOMAIN"
TARGET_DIR="/home/ubuntu/PomToolbox/certs"
TMUX_SESSION="pomtools"
DOCKER_COMPOSE_FILE="docker-compose.prod.yml"

# Logging function
log() {
    echo "[$(date '+%Y-%m-%d %H:%M:%S')] $1"
}

# Error handling function
error_exit() {
    log "ERROR: $1"
    exit 1
}

# Step 1: Renew Certificates
log "Renewing certificates for $DOMAIN..."
if ! sudo certbot renew --force-renewal; then
    error_exit "Failed to renew certificates."
fi
log "Certificates renewed successfully."

# Step 2: Copy Certificates
log "Copying certificates to $TARGET_DIR..."
if ! sudo cp "$CERT_DIR/fullchain.pem" "$TARGET_DIR/"; then
    error_exit "Failed to copy fullchain.pem."
fi
if ! sudo cp "$CERT_DIR/privkey.pem" "$TARGET_DIR/"; then
    error_exit "Failed to copy privkey.pem."
fi
log "Certificates copied successfully."

# Step 3: Restart Application
log "Restarting application in tmux session $TMUX_SESSION..."

# Kill existing tmux session if it exists
if tmux has-session -t "$TMUX_SESSION" 2>/dev/null; then
    log "Killing existing tmux session $TMUX_SESSION..."
    if ! tmux kill-session -t "$TMUX_SESSION"; then
        error_exit "Failed to kill tmux session $TMUX_SESSION."
    fi
fi

# Start a new tmux session and run Docker Compose
log "Starting new tmux session $TMUX_SESSION..."
if ! tmux new-session -d -s "$TMUX_SESSION" "docker compose -f $DOCKER_COMPOSE_FILE up --build"; then
    error_exit "Failed to start tmux session $TMUX_SESSION."
fi
log "Application restarted successfully in tmux session $TMUX_SESSION."

log "Certificate renewal and application restart completed successfully."