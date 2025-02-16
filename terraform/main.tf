resource "local_file" "sample_resource" {
  filename = var.filename
  content = var.content
}

resource "random_string" "random" {
  length = 10
  special = false
  upper = false
  number = false
}